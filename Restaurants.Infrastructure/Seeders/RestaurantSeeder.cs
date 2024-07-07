using Restaurants.Domain.Entities;
using Restaurants.Infrastructure.Persistence;

namespace Restaurants.Infrastructure.Seeders;

internal class RestaurantSeeder(RestaurantsDbContext dbContext) : IRestaurantSeeder
{
    public async Task Seed()
    {
        if (await dbContext.Database.CanConnectAsync())
        {
            if (!dbContext.Restaurants.Any())
            {
                var restaurants = new List<Restaurant>
                {
                    new()
                    {
                        Name = "McDonald's",
                        Description = "New Mc Donald's Restaurant in Town!",
                        Category = "Fast Food",
                        ContactEmail = "mcdo@mcdo.com",
                        ContactNumber = "1234567890",
                        Address = new Address
                        {
                            Street = "1234 McDonald's Street",
                            City = "McDonald's City",
                            PostalCode = "12345"
                        },
                        HasDelivery = true,
                        Dishes =
                        [
                            new Dish
                            {
                                Name = "Big Mac",
                                Description = "Two all-beef patties, special sauce, lettuce, cheese, pickles, onions on a sesame seed bun.",
                                Price = 5.99m
                            },

                            new Dish
                            {
                                Name = "McChicken",
                                Description = "A crispy chicken patty topped with lettuce and mayonnaise, served on a perfectly toasty bun.",
                                Price = 4.99m
                            }
                        ]
                    },
                    new()
                    {
                        Name = "Burger King",
                        Description = "New Burger King Restaurant in Town!",
                        Category = "Fast Food",
                        ContactEmail = "mcdo@mcdo.com",
                        ContactNumber = "9876543120",
                        HasDelivery = false,
                        Address = new Address
                        {
                            Street = "1234 Burger King Street",
                            City = "Burger King City",
                            PostalCode = "12345"
                        },
                        Dishes =
                        [
                            new Dish
                            {
                                Name = "Whopper",
                                Description = "A flame-grilled beef patty topped with juicy tomatoes, fresh lettuce, creamy mayonnaise, ketchup, crunchy pickles, and sliced white onions on a soft sesame seed bun.",
                                Price = 6.99m
                            },

                            new Dish
                            {
                                Name = "Chicken Fries",
                                Description =
                                    "Made with white meat chicken, our Chicken Fries are coated in a light crispy breading seasoned with savory spices and herbs.",
                                Price = 3.99m
                            }
                        ]
                    }
                };

                await dbContext.Restaurants.AddRangeAsync(restaurants);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}