using MediatR;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Dishes.Commands.CreateDish;
using Restaurants.Application.Dishes.Commands.DeleteAllDishes;
using Restaurants.Application.Dishes.Queries.GetAllDishesByRestaurantId;
using Restaurants.Application.Dishes.Queries.GetDishForRestaurantById;

namespace Restaurants.API.Controllers;

[Route("api/restaurants/{restaurantId}/dishes")]
[ApiController]
public class DishesController(IMediator mediator): ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> CreateDish([FromRoute] int restaurantId, [FromBody] CreateDishCommand command)
    {
        command.RestaurantId = restaurantId;
        var dishId = await mediator.Send(command);
        return CreatedAtAction(nameof(GetDishById), new {restaurantId, dishId}, null);
        
    }
    [HttpGet]
    public async Task<IActionResult> GetDishes([FromRoute] int restaurantId)
    {
        var dishes = await mediator.Send(new GetAllDishesByRestaurantIdQuery(restaurantId));
        return Ok(dishes);
    }
    [HttpGet("{dishId}")]
    public async Task<IActionResult> GetDishById([FromRoute] int restaurantId, [FromRoute] int dishId)
    {
        var dish = await mediator.Send(new GetDishForRestaurantByIdQuery(restaurantId, dishId));
        return Ok(dish);
    }
    [HttpDelete]
    public async Task<IActionResult> DeleteAllDishes([FromRoute] int restaurantId)
    {
        await mediator.Send(new DeleteAllDishesCommand(restaurantId));
        return NoContent();
    }
    
    
}