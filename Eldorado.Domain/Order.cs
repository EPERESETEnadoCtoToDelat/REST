namespace Eldorado.Domain
{
    public class Order
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid? DeliveryPointId { get; set; }
        public DeliveryPoint? DeliveryPoint { get; set; }
        public List<SelectedProduct> SelectedProducts { get; set; } = new();
        public int Price { get; set; }
        public Guid CustomerId { get; set; } 
        public Customer? Customer { get; set; }
        public Guid? CourierId { get; set; }
        public Courier? Courier { get; set; }

    }
}