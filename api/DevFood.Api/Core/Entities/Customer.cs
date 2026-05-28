namespace DevFood.Api.Core.Entities
{
    public class Customer : BaseEntity
    {
        public Customer(string fullName, string email, DateTime birthDate, string document, string phoneNumber, string fullAddress)
        {
            FullName = fullName;
            Email = email;
            BirthDate = birthDate;
            Document = document;
            PhoneNumber = phoneNumber;
            FullAddress = fullAddress;
            Addresses = [];
        }

        public string FullName { get; set; }

        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public string Document { get; set; }
        public string PhoneNumber { get; set; }
        public string FullAddress { get; set; }
        public List<CustomerAddress> Addresses { get; set; }

    }
}


