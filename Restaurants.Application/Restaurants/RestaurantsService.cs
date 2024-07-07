using AutoMapper;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants;

internal class RestaurantsService(IRestaurantsRepository restaurantsRepository,
    ILogger<RestaurantsService> logger, IMapper mapper) : IRestaurantsService
{
    public async Task<IEnumerable<RestaurantDto>> GetAllRestaurants()
    {
        logger.LogInformation("Getting all restaurants");
        var restaurants = await restaurantsRepository.GetAllAsync();
        
        var restaurantDtos = mapper.Map<IEnumerable<RestaurantDto>>(restaurants);
        return restaurantDtos!;
    }

    public async Task<RestaurantDto?> GetRestaurantById(int id)
    {
        logger.LogInformation("Getting restaurant by id");
        var restaurant = await restaurantsRepository.GetRestaurant(id);
        
        var restaurantDto = mapper.Map<RestaurantDto>(restaurant);
        return restaurantDto;
    }

    public async Task<int> CreateRestaurant(CreateRestaurantDto createRestaurantDto)
    {
        logger.LogInformation("Create restaurant");
        var restaurant = mapper.Map<Restaurant>(createRestaurantDto);
        int id = await restaurantsRepository.CreateAsync(restaurant);
        return id;
    }
}
