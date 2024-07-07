using AutoMapper;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;

namespace Restaurants.Application.Restaurants.DTOs;

public class RestaurantsProfile: Profile
{
    public RestaurantsProfile()
    {
        CreateMap<CreateRestaurantDto, Restaurant>()
            .ForMember(d=>d.Address, opt=>opt.MapFrom(
                src=>new Address
                {
                    Street = src.Street,
                    City = src.City,
                    PostalCode = src.PostalCode
                }));
        CreateMap<Restaurant, RestaurantDto>()
            .ForMember(d => d.Street, opt => opt.MapFrom(s => s.Address==null? null: s.Address.Street))
            .ForMember(d => d.City, opt => opt.MapFrom(s => s.Address==null? null: s.Address.City))
            .ForMember(d => d.PostalCode, opt => opt.MapFrom(s => s.Address==null? null: s.Address.PostalCode))
            .ForMember(d => d.Dishes, opt => opt.MapFrom(s => s.Dishes));
    }
    
}