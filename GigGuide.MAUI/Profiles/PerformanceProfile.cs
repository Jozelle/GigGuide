using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Profiles
{
    public class PerformanceProfile : Profile
    {
        public PerformanceProfile()
        {
            CreateMap<Performance,PerformanceDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.PerformanceId))
                .ForMember(dest => dest.PerformanceTime, opt => opt.MapFrom(src => src.PerformanceTime))
                .ForMember(dest => dest.TicketPrice, opt => opt.MapFrom(src => src.PerformanceTicketPrice))
                .ForMember(dest => dest.TicketsAvailable, opt => opt.MapFrom(src => src.PerformanceTotalTickets))
                .ForMember(dest => dest.ConcertId, opt => opt.MapFrom(src => src.PerformanceConcertId))
                .ForMember(dest => dest.VenueId, opt => opt.MapFrom(src => src.PerformanceVenueId));
            

            CreateMap<PerformanceDto, Performance>()
                .ForMember(dest => dest.PerformanceId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.PerformanceTime, opt => opt.MapFrom(src => src.PerformanceTime))
                .ForMember(dest => dest.PerformanceTicketPrice, opt => opt.MapFrom(src => src.TicketPrice))
                .ForMember(dest => dest.PerformanceTotalTickets, opt => opt.MapFrom(src => src.TicketsAvailable))
                .ForMember(dest => dest.PerformanceConcertId, opt => opt.MapFrom(src => src.ConcertId))
                .ForMember(dest => dest.PerformanceConcert, opt => opt.MapFrom(src => src.Concert))
                .ForMember(dest => dest.PerformanceVenueId, opt => opt.MapFrom(src => src.VenueId))
                .ForMember(dest => dest.PerformanceVenue, opt => opt.MapFrom(src => src.Venue));
        }
    }
}
