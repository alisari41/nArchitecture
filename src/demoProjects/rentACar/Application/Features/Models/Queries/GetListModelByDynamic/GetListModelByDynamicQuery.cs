using Application.Features.Models.Models;
using Application.Services.Repositories;
using AutoMapper;
using Core.Application.Requests;
using Core.Persistence.Dynamic;
using Core.Persistence.Paging;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Models.Queries.GetListModelByDynamic
{
    public class GetListModelByDynamicQuery : IRequest<ModelListModel>
    {
        public Dynamic Dynamic { get; set; } // Dinamik sorgu yazmak için kullanacağız
        public PageRequest PageRequest { get; set; }

        public class GetListModelByDinamicQeuryHandler : IRequestHandler<GetListModelByDynamicQuery, ModelListModel>
        {
            private readonly IModelRepository _modelRepository;
            private readonly IMapper _mapper;

            public GetListModelByDinamicQeuryHandler(IModelRepository modelRepository, IMapper mapper)
            {
                _modelRepository = modelRepository;
                _mapper = mapper;
            }

            public async Task<ModelListModel> Handle(GetListModelByDynamicQuery request, CancellationToken cancellationToken)
            {

                IPaginate<Model> models = await _modelRepository.GetListByDynamicAsync( // Dinamik Sorgu
                                                request.Dynamic,
                                                include: x => x.Include(c => c.Brand),
                                                index: request.PageRequest.Page,
                                                size: request.PageRequest.PageSize);


                var mappedModelListModel = _mapper.Map<ModelListModel>(models); // Gelen datayı ModelListModel 'a çeviriyorum

                return mappedModelListModel;
            }
        }
    }
}
