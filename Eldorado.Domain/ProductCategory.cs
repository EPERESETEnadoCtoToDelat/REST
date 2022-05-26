namespace Eldorado.Domain
{
    public class ProductCategory
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public List<Product>? Products { get; set; } 
    }
}