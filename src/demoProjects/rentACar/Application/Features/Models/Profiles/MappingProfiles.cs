using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Profiles
{
    public class MappingProfiles : Profile
    {
        // AutoMapper'in Profile sınıfından kalıtım alınır.

        // Mapleme profilleri yazılır
        public MappingProfiles()
        {
            // AutoMapper'in Profile Sınıfından gelir Amacı: Neyi Neye maplicez Source:kaynak Destination: Hedef

            #region İlişkili tabloları map işlemi yapılamsı gerekir

            #region İlişkili Tabloda Mapleme işlemi gerçekleştirmesi
            // ModelListDto içerisindeki BrandName değişkenini Model sınıfı içersinde Brand'in içindeki Name'den oku
            CreateMap<Model, ModelListDto>()
                        .ForMember(x => x.BrandName, opt => opt.MapFrom(x => x.Brand.Name))
                        // .ForMember(x => x.BrandName, opt => opt.MapFrom(x => x.Brand.Name))     Mesela Başka alanlarıda bu şekilde MAPleyebiliriz           
                        .ReverseMap(); // BrandName'i map işlemi yapamayacağı için biz verdik
            #endregion

            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
            #endregion

        }

    }
}
