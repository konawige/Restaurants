using Restaurants.Domain.Entities;

namespace Restaurants.Application.Dishes.DTOs;

public class DishDto
{
    public int Id { get; set; } = default!;
    public string? Name { get; set; } = default!;
    public string? Description { get; set; } = default!;
    public decimal Price { get; set; }
    
    public int? KiloCalories { get; set; }
    
    public int RestaurantId { get; set; }
    
}