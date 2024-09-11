using AutoMapper;
using SolarLab.Academy.Contracts.Categories;
using SolarLab.Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolarLab.Academy.ComponentRegistrar.MapProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryInfoModel>()
                .ForMember(s => s.Title, map => map.MapFrom(s => s.Name));


            CreateMap<CategoryCreateModel, Category>(MemberList.None)
                .ForMember(s => s.Name, map => map.MapFrom(s => s.Title))
                .ForMember(s => s.Created, map => map.MapFrom(s => DateTime.UtcNow));
        }
    }
}