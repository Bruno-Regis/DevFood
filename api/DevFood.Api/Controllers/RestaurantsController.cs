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
    }



    public class CreateRestaurantCommand
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<Guid> Categories { get; set; } = [];
        public decimal? MinimumOrderAmount { get; set; }
    }


}
