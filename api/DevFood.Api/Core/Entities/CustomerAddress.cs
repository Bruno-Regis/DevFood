namespace DevFood.Api.Core.Entities
{
    public class CustomerAddress : BaseEntity
    {
        public CustomerAddress(string nickName, string address1, string address2, string zipCode, string district, string city, string state, string country, Guid costumerId)
        {
            NickName = nickName;
            Address1 = address1;
            Address2 = address2;
            ZipCode = zipCode;
            District = district;
            City = city;
            State = state;
            Country = country;
            CostumerId = costumerId;
        }

        public string NickName { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string ZipCode { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public Guid CostumerId { get; set; }


    }
}
