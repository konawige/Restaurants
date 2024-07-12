using MediatR;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Restaurants.Application.Restaurants;
using Restaurants.Application.Restaurants.Commands.CreateRestaurant;
using Restaurants.Application.Restaurants.Commands.DeleteRestaurant;
using Restaurants.Application.Restaurants.Commands.UpdateRestaurant;
using Restaurants.Application.Restaurants.DTOs;
using Restaurants.Application.Restaurants.Queries.GetAllRestaurants;
using Restaurants.Application.Restaurants.Queries.GetRestaurantById;

namespace Restaurants.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<RestaurantDto>), StatusCodes.Status200OK)]
    public async Task<IActionResult> GetAll()
    {
        var restaurants = await mediator.Send(new GetAllRestaurantsQuery());
        return Ok(restaurants);
    }
    [HttpGet("{id:int}")]
    public async Task<ActionResult<RestaurantDto>> GetById([FromRoute] int id) 
    {
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }
    [HttpPost]
    public async Task<IActionResult> CreateRestaurant([FromBody] CreateRestaurantCommand command)
    {
        int id = await mediator.Send(command);
        return CreatedAtAction(nameof(GetById), new {id }, null);
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateRestaurant([FromRoute] int id, [FromBody] UpdateRestaurantCommand command)
    {
        command.Id = id;
        await mediator.Send(command);
       
        // return the updated entity
        
        var restaurant = await mediator.Send(new GetRestaurantByIdQuery(id));
        return Ok(restaurant);
    }
    
    [HttpDelete("{id:int}")]
    [ProducesResponseType( StatusCodes.Status204NoContent)]
    [ProducesResponseType( StatusCodes.Status404NotFound)
    ]
    public async Task<IActionResult> DeleteRestaurant([FromRoute] int id) 
    {
        await mediator.Send(new DeleteRestaurantCommand(id));
        //return 204 No Content
        return NoContent();
    }
}