namespace Eldorado.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Image { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }
        public string Description { get; set; } = string.Empty;
        public string Specifications { get; set; } = string.Empty;
        public string Producer { get; set; } = string.Empty;
        public List<SelectedProduct>? SelectedProducts { get; set; } 
        public Guid? ProductCategoryId { get; set; }
        public ProductCategory? ProductCategory { get; set; }
    }
}