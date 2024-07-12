using AutoMapper;
using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommandHandler(ILogger<UpdateRestaurantCommandHandler> logger,
    IMapper mapper, IRestaurantsRepository restaurantsRepository ): IRequestHandler<UpdateRestaurantCommand>
{
    public async Task Handle(UpdateRestaurantCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Search for the restaurant");
        var restaurant = await restaurantsRepository.GetRestaurant(request.Id);
        if (restaurant is null)
        {
            /*logger.LogWarning("Restaurant not found");
            return false;*/
            throw new NotFoundExceptions(nameof(Restaurant), request.Id.ToString());
        }
        logger.LogInformation("Updating the restaurant");
        if (request.Name != null) restaurant.Name = request.Name;
        if (request.Description != null) restaurant.Description = request.Description;
        if (request.Category != null) restaurant.Category = request.Category;
        if (request.HasDelivery != null) restaurant.HasDelivery = (bool)request.HasDelivery;
        await restaurantsRepository.SaveChanges();
    }
}