namespace Eldorado.Domain
{
    public class Cart
    {
        public Guid Id { get; set; }
        public List<SelectedProduct> SelectedProducts { get; set; } = new();
        public int Price { get; set; }
        public Guid CustomerId { get; set; }
        public Customer? Customer { get; set; }
    }
}