using MediatR;

namespace Eldorado.Application.ProductCatigories.Commands.DeleteProductCategory;

public class DeleteProductCategoryCommand : IRequest
{
    public Guid Id { get; set; }
}