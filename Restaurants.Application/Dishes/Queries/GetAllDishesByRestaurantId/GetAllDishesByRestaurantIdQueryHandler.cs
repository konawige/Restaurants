using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Dishes.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Queries.GetAllDishesByRestaurantId;

public class GetAllDishesByRestaurantIdQueryHandler(ILogger<GetAllDishesByRestaurantIdQueryHandler> logger,
    IRestaurantsRepository restaurantsRepository, IDishesRepository dishesRepository,
    IMapper mapper) : IRequestHandler<GetAllDishesByRestaurantIdQuery, IEnumerable<DishDto>>
{
    public async Task<IEnumerable<DishDto>> Handle(GetAllDishesByRestaurantIdQuery request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.RestaurantId) ?? 
                         throw new NotFoundExceptions(nameof(Restaurant), request.RestaurantId.ToString());
        logger.LogInformation("Get all Dishes  for restaurant {@restaurant}", restaurant.Name);
        var dishes = await dishesRepository.GetDishesByRestaurantId(request.RestaurantId);
        var dishDtos = mapper.Map<IEnumerable<DishDto>>(dishes);
        return dishDtos;
    }
}