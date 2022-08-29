using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        // Son kullanıcının bize göndereceği son dataları içeren yapı
        public string Name { get; set; }

        // Bir tanede Handlerımız var yani böyle bir command sıraya koyulursa hangi Handler çalışacak onu IRequestHandler olduğunu belirtiyoruz. Hem çalışacağımız command'i hemde dönüş tipimizi belirtiyoruz.
        public class CreateBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {
            // IRequestHandler implement edilmesi gerekir.

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreateBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name); // BusinessRules lerin yazılıyor.



                Brand mappedBrand = _mapper.Map<Brand>(request); // mapper kullanarak Parametre olarak gelen "request"'i Brand nesnesine çevir
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand); // repository kullanarak ekleme işlemini gerçekleştirmem gerekiyor     (createdBrand veritabanından dönen brand)


                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand); // Bizim veritabanından gelen nesneyi DTO ya çevirmemiz lazım

                // Mapper bu satır aşağıdaki satırlara eşittir isimlendirmeye göre kendi otomatik eşitler
                //CreatedBrandDto createdBrandDto=new CreatedBrandDto();
                //createdBrandDto.Id = mappedBrand.Id;
                //createdBrandDto.Name = mappedBrand.Name;


                // AutoMapper (2 nesneyi birbirine eşlemeyi sağlayan basit bir kütüphanedir)  bize dönüşüm yapmamızı sağlar mesela
                // Dto -> id, name
                // Brand -> id, name, x
                // Mapper ile isim benzerlikleri ile çevirmeyi sağlar bu sayede veritabanındaki bütün nesneleri kullanıcıya döndürmemiş oluruz

                return createdBrandDto;
            }
        }
    }
}
