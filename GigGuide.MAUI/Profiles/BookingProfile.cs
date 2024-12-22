using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Profiles
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BookingId))
                .ForMember(dest => dest.Quantity, opt => opt.MapFrom(src => src.BookingQuantity))
                .ForMember(dest => dest.PerformanceId, opt => opt.MapFrom(src => src.BookingPerformanceId))
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.BookingCustomerId));
            CreateMap<BookingDto, Booking>()
                .ForMember(dest => dest.BookingId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.BookingQuantity, opt => opt.MapFrom(src => src.Quantity))
                .ForMember(dest => dest.BookingPerformanceId, opt => opt.MapFrom(src => src.PerformanceId))
                .ForMember(dest => dest.BookingCustomerId, opt => opt.MapFrom(src => src.CustomerId));
        }
    }
}
