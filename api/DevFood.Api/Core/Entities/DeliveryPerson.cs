using DevFood.Api.Core.Enums;

namespace DevFood.Api.Core.Entities
{
    public class DeliveryPerson : BaseEntity
    {
        public DeliveryPerson(string name, string email, DateTime birthDate, string document, string phoneNumber, string fullAddress)
        {
            Name = name;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            PhoneNumber = phoneNumber;
            FullAddress = fullAddress;
            Status = DeliveryPersonStatus.Available;
        }

        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public DeliveryPersonStatus Status { get; set; }
    }
}
