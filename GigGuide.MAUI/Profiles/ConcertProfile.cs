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

            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.Phone));
        }
    }
}
