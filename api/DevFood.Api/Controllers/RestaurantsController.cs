using DevFood.Api.Core.Entities;
using DevFood.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFood.Api.Controllers
{
    [ApiController]
    [Route("api/restaurants")]
    public class RestaurantsController : ControllerBase
    {
        private readonly DeliveryDbContext _dbContext;

        public RestaurantsController(DeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult CreateRestaurant(CreateRestaurantCommand command)
        {
            var restaurant = new Restaurant(
                command.Title,
                command.Description,
                command.Address,
                command.Categories,
                command.MinimumOrderAmount);

            _dbContext.Restaurants.Add(restaurant);

            return Ok(restaurant.Id);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var restaurants = _dbContext.Restaurants
                .Select(c => RestaurantModel.FromEntity(c))
                .ToList();

            return Ok(restaurants);
        }



        public class CreateRestaurantCommand
        {
            public string Title { get; set; } = string.Empty;
            public string Description { get; set; } = string.Empty;
            public string Address { get; set; } = string.Empty;
            public List<Guid> Categories { get; set; } = [];
            public decimal? MinimumOrderAmount { get; set; }
        }

        public class RestaurantModel
        {
            public RestaurantModel(Guid id, string title, string description, string address, List<Guid> categories, decimal? minimumOrderAmount)
            {
                Id = id;
                Title = title;
                Description = description;
                Address = address;
                Categories = categories;
                MinimumOrderAmount = minimumOrderAmount;
            }

            public Guid Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public string Address { get; set; }
            public List<Guid> Categories { get; set; }
            public decimal? MinimumOrderAmount { get; set; }

            public static RestaurantModel FromEntity(Restaurant restaurant)
                => new RestaurantModel(
                    restaurant.Id,
                    restaurant.Title,
                    restaurant.Description,
                    restaurant.Address,
                    restaurant.Categories.Select(c => c.CategoryId).ToList(),
                    restaurant.MinimumOrderAmount);
        }

    }
}
