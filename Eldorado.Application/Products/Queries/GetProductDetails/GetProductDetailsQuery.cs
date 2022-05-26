using MediatR;

namespace Eldorado.Application.Products.Queries.GetProductDetails;

public class GetProductDetailsQuery : IRequest<ProductDetailsVm>
{
    public Guid Id { get; set; }
}