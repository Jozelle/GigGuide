using AutoMapper;
using GigGuide.Data.DTO;
using GigGuide.MAUI.Models;

namespace GigGuide.MAUI.Profiles
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerDto>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.CustomerId))
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.CustomerFirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.CustomerLastName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.CustomerEmail))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.CustomerPhone));

            CreateMap<CustomerDto, Customer>()
                .ForMember(dest => dest.CustomerId, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.CustomerFirstName, opt => opt.MapFrom(src => src.FirstName))
                .ForMember(dest => dest.CustomerLastName, opt => opt.MapFrom(src => src.LastName))
                .ForMember(dest => dest.CustomerEmail, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.CustomerPhone, opt => opt.MapFrom(src => src.Phone));
        }
    }
}
 