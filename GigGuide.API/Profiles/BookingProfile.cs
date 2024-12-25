using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.Data.Entities;

namespace GigGuide.API.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.PerformanceId, opt => opt.MapFrom(src => src.PerformanceId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.Performance, opt => opt.MapFrom(src => src.Performance));

            CreateMap<BookingDto, Booking>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.PerformanceId, opt => opt.MapFrom(src => src.PerformanceId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.CustomerId));
        }
    }
}
