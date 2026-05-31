using DevFood.Api.Core.Entities;
using DevFood.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFood.Api.Controllers
{
    [ApiController]
    [Route("api/delivery-persons")]
    public class DeliveryPersonsController : ControllerBase
    {
        private readonly DeliveryDbContext _dbContext;
        public DeliveryPersonsController(DeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public IActionResult Create(CreateDeliveryPersonCommand command)
        {
            var deliveryPerson = new DeliveryPerson(command.Name, command.Email, command.BirthDate, command.Document, command.PhoneNumber, command.FullAddress);
            
            _dbContext.DeliveryPersons.Add(deliveryPerson);
            return Ok(deliveryPerson.Id);
        }
    }

    public class CreateDeliveryPersonCommand
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Document { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
