using Microsoft.EntityFrameworkCore;
using Restaurants.Domain.Entities;
using Restaurants.Domain.Repositories;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Repositories;

internal class DishesRepository(RestaurantsDbContext dbContext): IDishesRepository
{
    public async Task<int> CreateAsync(Dish dish)
    {
        //create a new dish for a restaurant
        dbContext.Dishes.Add(dish);
        await dbContext.SaveChangesAsync();
        return dish.Id;
    }

    public async Task<IEnumerable<Dish>> GetDishesByRestaurantId(int restaurantId)
    {
        //get all dishes for a restaurant
        return await dbContext.Dishes.Where(d => d.RestaurantId == restaurantId).ToListAsync();
    }

    public async Task<Dish?> GetDishById(int restaurantId, int id)
    {
        //get a dish by id for a restaurant
        return await dbContext.Dishes.FirstOrDefaultAsync(d => d.RestaurantId == restaurantId && d.Id == id);
    }
}