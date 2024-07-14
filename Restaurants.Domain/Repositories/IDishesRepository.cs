using Restaurants.Domain.Entities;

namespace Restaurants.Domain.Repositories;

public interface IDishesRepository
{
    public Task<int> CreateAsync(Dish dish);
    public Task<IEnumerable<Dish>> GetDishesByRestaurantId(int restaurantId);
    public Task<Dish?> GetDishById(int restaurantId, int id);

}