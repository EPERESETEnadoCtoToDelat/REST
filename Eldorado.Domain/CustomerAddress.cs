namespace Eldorado.Domain
{
    public class CustomerAddress
    {
        public Guid Id { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int House { get; set; }
        public int Apartment { get; set; }
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}
