using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Profiles
{
    public class MappingProfiles : Profile
    {
        // AutoMapper'in Profile sınıfından kalıtım alınır.

        // Mapleme profilleri yazılır
        public MappingProfiles()
        {
            // AutoMapper'in Profile Sınıfından gelir Amacı: Neyi Neye maplicez Source:kaynak Destination: Hedef
            CreateMap<Brand, CreatedBrandDto>().ReverseMap(); // ReverseMap() iki türlüde mapleme yapmayı sağlar
            CreateMap<Brand, CreateBrandCommand>().ReverseMap(); // ReverseMap() iki türlüde mapleme yapmayı sağlar
            CreateMap<IPaginate<Brand>, BrandListModel>().ReverseMap();
        }
    }
}
