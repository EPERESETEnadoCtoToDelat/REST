namespace Eldorado.Domain
{
    public class CreditCard
    {
        public Guid Id { get; set; }
        public long Number { get; set; }
        public string OwnerName { get; set; } = string.Empty;
        public int CVV2 { get; set; }
        public DateTime EndDate { get; set; }
        public Guid? CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}