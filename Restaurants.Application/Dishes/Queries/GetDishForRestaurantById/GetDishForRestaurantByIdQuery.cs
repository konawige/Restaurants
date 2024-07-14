using MediatR;
using Restaurants.Application.Dishes.DTOs;

namespace Restaurants.Application.Dishes.Queries.GetDishForRestaurantById;

public class GetDishForRestaurantByIdQuery(int restaurantId, int id) : IRequest<DishDto>
{
    public int RestaurantId { get; } = restaurantId;
    public int Id { get; } = id;
}
