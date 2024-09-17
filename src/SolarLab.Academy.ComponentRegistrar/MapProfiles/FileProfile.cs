using AutoMapper;
using SolarLab.Academy.Contracts.Contexts.Files;
using SolarLab.Academy.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using File = SolarLab.Academy.Domain.File;

namespace SolarLab.Academy.ComponentRegistrar.MapProfiles
{
    public class FileProfile : Profile
    {
        public FileProfile() 
        {
            CreateMap<File, FileInfoDto>();

            CreateMap<FileDto, File>()
                .ForMember(s => s.Id, map => map.MapFrom(s => Guid.NewGuid()))
                .ForMember(s => s.Length, map => map.MapFrom(s => s.Content.Length))
                .ForMember(s => s.Created, map => map.MapFrom(s => DateTime.UtcNow));
        }
    }
}
