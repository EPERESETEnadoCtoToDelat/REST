using MediatR;

namespace Eldorado.Application.ProductCatigories.Commands.UpdateProductCategory;

public class UpdateProductCategoryCommand : IRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
}