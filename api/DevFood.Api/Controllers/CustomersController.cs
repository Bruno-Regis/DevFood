using DevFood.Api.Core.Entities;
using DevFood.Api.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace DevFood.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomersController : ControllerBase
    {
        private readonly DeliveryDbContext _dbContext;
        public CustomersController(DeliveryDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult Create(CreateCustomerCommand command)
        {
            var customer = new Customer(command.FullName, command.Email, command.BirthDate, command.Document, command.PhoneNumber, string.Empty);
            
            _dbContext.Customers.Add(customer);
            return Ok(customer.Id);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var customers = _dbContext
                .Customers
                .Select(c => CustomerModel.FromEntity(c))
                .ToList();

            return Ok(customers);
        }

        // api/customers/12331-23abas-123as/addresses
        [HttpPost("{id}/addresses")]
        public IActionResult CreateAddress(Guid id, CreateCustomerAddressCommand command)
        {
            var customerAddress = new CustomerAddress(command.NickName, command.Address1, command.Address2, command.ZipCode, command.District, command.City, command.State, command.Country, id);
            

            var customer = _dbContext.Customers.SingleOrDefault(c => c.Id == id);

            if (customer == null)
                return NotFound();

            customer.Addresses.Add(customerAddress);
            return Ok(customerAddress.Id);
        }
    }

    public class CreateCustomerCommand
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public DateTime BirthDate { get; set; }
        public string Document { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
    }

    public class CreateCustomerAddressCommand
    {
        public string NickName { get; set; } = string.Empty;
        public string Address1 { get; set; } = string.Empty;
        public string Address2 { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }

    public class CustomerModel
    {
        public CustomerModel(Guid Id, string fullName, string email, DateTime birthDate, string document, string phoneNumber)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            PhoneNumber = phoneNumber;
        }

        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; } 
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }

        public static CustomerModel FromEntity(Customer customer)
            => new CustomerModel(customer.Id, customer.FullName, customer.Email, customer.BirthDate, customer.Document, customer.PhoneNumber);
    }
}
