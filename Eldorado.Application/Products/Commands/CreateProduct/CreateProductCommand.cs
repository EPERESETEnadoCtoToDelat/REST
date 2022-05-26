using MediatR;

namespace Eldorado.Application.Products.Commands.CreateProduct;

public class CreateProductCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public Guid ProductCategoryId { get; set; }
}