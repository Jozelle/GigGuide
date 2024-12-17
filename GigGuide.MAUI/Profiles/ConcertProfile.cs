using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Profiles
{
    public class ConcertProfile : Profile
    {
        public ConcertProfile()
        {
            CreateMap<Concert, ConcertDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ConcertId))
                .ForMember(dest => dest.Artist, opt => opt.MapFrom(src => src.ConcertArtist))
                .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.ConcertTitle))
                .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.ConcertDescription))
                .ForMember(dest => dest.Performances, opt => opt.MapFrom(src => src.ConcertPerformances));

            CreateMap<ConcertDto, Concert>()
                .ForMember(dest => dest.ConcertId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.ConcertArtist, opt => opt.MapFrom(src => src.Artist))
                .ForMember(dest => dest.ConcertTitle, opt => opt.MapFrom(src => src.Title))
                .ForMember(dest => dest.ConcertDescription, opt => opt.MapFrom(src => src.Description))
                .ForMember(dest => dest.ConcertPerformances, opt => opt.MapFrom(src => src.Performances));
        }
    }
}
