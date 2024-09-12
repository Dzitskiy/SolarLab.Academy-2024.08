using AutoMapper;
using SolarLab.Academy.Contracts.Contexts.Adverts.Requests;
using SolarLab.Academy.Contracts.Contexts.Adverts.Responses;
using SolarLab.Academy.Domain;

namespace SolarLab.Academy.ComponentRegistrar.MapProfiles;

public class AdvertProfile : Profile
{
    public AdvertProfile()
    {
        CreateMap<CreateAdvertRequest, Advert>(MemberList.None);

        CreateMap<Advert, ShortAdvertResponse>(MemberList.None);

        CreateMap<Advert, AdvertResponse>(MemberList.None);
    }
}