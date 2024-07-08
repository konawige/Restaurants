using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository ): IRequestHandler<DeleteRestaurantCommand,bool>
{
    public async Task<bool> Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Search for the restaurant");
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant is null)
        {
            logger.LogWarning("Restaurant not found");
            return false;
        }
        logger.LogInformation("Deleting the restaurant");
        await restaurantsRepository.DeleteAsync(restaurant);
        return true;
    }
}