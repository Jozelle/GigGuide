using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Profiles
{
    public class VenueProfile : Profile
    {
        public VenueProfile()
        {
            CreateMap<Venue, VenueDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.VenueId))
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.VenueName))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.VenueAddress))
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.VenueCity))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.VenueCountry))
                .ForMember(dest => dest.Longitude, opt => opt.MapFrom(src => src.VenueLongitude))
                .ForMember(dest => dest.Latitude, opt => opt.MapFrom(src => src.VenueLatitude));

            CreateMap<VenueDto, Venue>()
                .ForMember(dest => dest.VenueId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.VenueName, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.VenueAddress, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.VenueCity, opt => opt.MapFrom(src => src.City))
                .ForMember(dest => dest.VenueCountry, opt => opt.MapFrom(src => src.Country))
                .ForMember(dest => dest.VenueLongitude, opt => opt.MapFrom(src => src.Longitude))
                .ForMember(dest => dest.VenueLatitude, opt => opt.MapFrom(src => src.Latitude));
        }
    }
}
