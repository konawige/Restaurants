using MediatR;
using Restaurants.Application.Restaurants.DTOs;

namespace Restaurants.Application.Restaurants.Commands.UpdateRestaurant;

public class UpdateRestaurantCommand: IRequest
{
    public int Id { get; set; } = default!;
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? Category { get; set; }
    public bool? HasDelivery { get; set; }
}