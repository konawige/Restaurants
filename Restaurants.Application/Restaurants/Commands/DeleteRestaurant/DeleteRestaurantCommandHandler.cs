using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.DeleteRestaurant;

public class DeleteRestaurantCommandHandler(ILogger<DeleteRestaurantCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository ): IRequestHandler<DeleteRestaurantCommand>
{
    public async Task Handle(DeleteRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Search for the restaurant");
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant is null)
        {
           /* logger.LogWarning("Restaurant not found");
            return false;*/
           throw new NotFoundExceptions(nameof(Restaurant), request.Id.ToString());
        }
        logger.LogInformation("Deleting the restaurant with id: {@Id}", request.Id);
        await restaurantsRepository.DeleteAsync(restaurant);
    }
}