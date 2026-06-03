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

        [HttpGet]
        public IActionResult GetAll()
        {
            var deliveryPersons = _dbContext.DeliveryPersons
                .Select(c => DeliveryPersonModel.FromEntity(c))
                .ToList();
            return Ok(deliveryPersons);
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

    public class DeliveryPersonModel
    {
        public DeliveryPersonModel(Guid id, string name, string email, DateTime birthDate, string document, string phoneNumber, string fullAddress)
        {
            Id = id;
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            PhoneNumber = phoneNumber;
            FullAddress = fullAddress;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }

        public static DeliveryPersonModel FromEntity(DeliveryPerson deliveryPerson)
            => new DeliveryPersonModel(deliveryPerson.Id, deliveryPerson.Name, deliveryPerson.Email, deliveryPerson.BirthDate, deliveryPerson.Document, deliveryPerson.PhoneNumber, deliveryPerson.FullAddress);
    }

}