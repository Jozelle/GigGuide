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
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Artist))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.Performances, opt => opt.MapFrom(src => src.Performances));

            CreateMap<ConcertDto, Concert>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.Artist))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description));
        }
    }
}
