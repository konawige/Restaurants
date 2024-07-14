using MediatR;

namespace Restaurants.Application.Dishes.Commands.DeleteAllDishes;

public class DeleteAllDishesCommand(int restaurantId) : IRequest
{
    public int RestaurantId { get; } = restaurantId;
}