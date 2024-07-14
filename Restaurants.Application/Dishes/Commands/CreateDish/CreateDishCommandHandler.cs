using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.CreateDish;

public class CreateDishCommandHandler(ILogger<CreateDishCommandHandler> logger,
    IMapper mapper, IRestaurantsRepository restaurantsRepository,
    IDishesRepository dishesRepository ): IRequestHandler<CreateDishCommand,int>
{
    public async Task<int> Handle(CreateDishCommand request, CancellationToken cancellationToken)
    {
        var restaurant = await restaurantsRepository.GetRestaurant(request.RestaurantId) ?? 
                         throw new NotFoundExceptions(nameof(Restaurant), request.RestaurantId.ToString());
        logger.LogInformation("Create Dish {@Dish} for restaurant {@restaurant}", request, restaurant.Name);
        var dish = mapper.Map<Dish>(request);
        int id = await dishesRepository.CreateAsync(dish);
        return id;
    }
}