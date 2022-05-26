namespace Eldorado.Domain
{
    public class SelectedProduct
    {
        public Guid Id { get; set; }
        public Guid? ProductId { get; set; }//fwfwe
        public Product? Product { get; set; }
        public int Count { get; set; }
        public Guid? CartId { get; set; }
        public Cart? Cart { get; set; }
        public Guid? OrderId { get; set; }
        public Order? Order { get; set; }
    }
}