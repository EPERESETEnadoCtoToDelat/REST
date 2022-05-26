using FluentValidation;

namespace Eldorado.Application.Products.Queries.GetProductDetails;

public class GetProductDetailsQueryValidator : AbstractValidator<GetProductDetailsQuery>
{
    public GetProductDetailsQueryValidator()
    {
        RuleFor(getProductDetailsQuery =>
            getProductDetailsQuery.Id).NotNull().NotEqual(Guid.Empty);
    }
}