using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Application.Dishes.Queries.GetAllDishesByRestaurantId;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurantById;

public class GetDishForRestaurantByIdQueryHandler(ILogger<GetDishForRestaurantByIdQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository,
    IMapper mapper) : IRequestHandler<GetDishForRestaurantByIdQuery, DishDto>
{
    public async Task<DishDto> Handle(GetDishForRestaurantByIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.RestaurantId) ?? 
                         throw new NotFoundExceptions(nameof(Restaurant), request.RestaurantId.ToString());
        logger.LogInformation("Get Dish {@dishId}  for restaurant {@restaurant}", request.Id, restaurant.Name);
        var dish = await dishesRepository.GetDishById(request.RestaurantId, request.Id) ?? 
                   throw new NotFoundExceptions(nameof(Dish), request.Id.ToString());
        
        var dishDto = mapper.Map<DishDto>(dish);
        return dishDto;
    }
}