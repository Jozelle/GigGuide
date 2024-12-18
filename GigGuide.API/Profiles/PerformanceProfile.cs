using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.Data.Entities;

namespace GigGuide.API.Profiles
{
    public class PerformanceProfile : Profile   
    {
        public PerformanceProfile() 
        {
            CreateMap<Performance, PerformanceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PerformanceTime, opt => opt.MapFrom(src => src.PerformanceTime))
                .ForMember(dest => dest.TicketPrice, opt => opt.MapFrom(src => src.TicketPrice))
                .ForMember(dest => dest.TicketsAvailable, opt => opt.MapFrom(src => src.TicketsAvailable))
                .ForMember(dest => dest.ConcertId, opt => opt.MapFrom(src => src.ConcertId))
                .ForMember(dest => dest.VenueId, opt => opt.MapFrom(src => src.VenueId))
                ;

            CreateMap<PerformanceDto, Performance>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PerformanceTime, opt => opt.MapFrom(src => src.PerformanceTime))
                .ForMember(dest => dest.TicketPrice, opt => opt.MapFrom(src => src.TicketPrice))
                .ForMember(dest => dest.TicketsAvailable, opt => opt.MapFrom(src => src.TicketsAvailable))
                .ForMember(dest => dest.ConcertId, opt => opt.MapFrom(src => src.ConcertId))
                .ForMember(dest => dest.VenueId, opt => opt.MapFrom(src => src.VenueId))
                ;
        }
    }
}
