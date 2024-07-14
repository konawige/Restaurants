using MediatR;
using Microsoft.Extensions.Logging;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Exceptions;
using Restaurants.Domain.Repositories;

namespace Restaurants.Application.Dishes.Commands.DeleteAllDishes;

public class DeleteAllDishesCommandHandler(ILogger<DeleteAllDishesCommandHandler> logger,
    IRestaurantsRepository restaurantsRepository ): IRequestHandler<DeleteAllDishesCommand>
{
    public async Task Handle(DeleteAllDishesCommand request, CancellationToken cancellationToken)
    {
        logger.LogInformation("Search for the restaurant");
        var restaurant = await restaurantsRepository.GetRestaurant(request.RestaurantId)  ?? 
                         throw new NotFoundExceptions(nameof(Restaurant), request.RestaurantId.ToString());
            
        logger.LogInformation("Deleting all dishes for restaurant: {@name}", restaurant.Name);
        await restaurantsRepository.DeleteDishesAsync(restaurant);
    }
}