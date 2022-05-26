using MediatR;

namespace Eldorado.Application.ProductCatigories.Commands.CreateProductCategory;

public class CreateProductCategoryCommand : IRequest<Guid>
{
    public string Name { get; set; } = string.Empty;
}