using MediatR;

namespace Eldorado.Application.ProductCatigories.Queries.GetProductCategoryDetails;

public class GetProductCategoryDetailsQuery : IRequest<ProductCategoryDetailsVm>
{
    public Guid Id { get; set; }
}