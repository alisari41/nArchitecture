using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Queries.GetListModel
{
    public class GetListModelQuery : IRequest<ModelListModel>
    {
        // Mediator da IRequest
        public PageRequest PageRequest { get; set; } // Bir listeleme yapılacağı için bir Request üzerinden geçekleştirilecek

        public class GetListModelQeuryHandler : IRequestHandler<GetListModelQuery, ModelListModel>
        {
            // IRequestHandler<GetListModelQuery, ModelListModel> bu satır amacı GetListModelQuery bunu gönderildiğinde hangi Handler çalışıcak 

            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelQeuryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetListModelQuery request, CancellationToken cancellationToken)
            {
                // Araba modelleri
                IPaginate<Model> models = await _modelRepository.GetListAsync(include:
                                                x => x.Include(c => c.Brand), // Include işlemi ilişkilendirme için
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize); // Birden fazla ilişkide yapılabilir. Github Projesinden bakılabilir. Linkedinde paylaşıldı.


                var mappedModelListModel = _mapper.Map<ModelListModel>(models); // Gelen datayı ModelListModel 'a çeviriyorum

                return mappedModelListModel;
            }
        }
    }
}
