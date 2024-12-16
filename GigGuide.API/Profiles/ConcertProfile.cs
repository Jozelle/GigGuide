using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.Data.Entities;

namespace GigGuide.API.Profiles
{
    public class ConcertProfile : Profile   
    {
        public ConcertProfile()
        {
            CreateMap<Concert, ConcertDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));

            CreateMap<ConcertDto, Concert>();
        }
    }
}
