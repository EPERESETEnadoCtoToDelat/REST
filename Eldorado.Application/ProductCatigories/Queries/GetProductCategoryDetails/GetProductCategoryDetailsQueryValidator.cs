using FluentValidation;

namespace Eldorado.Application.ProductCatigories.Queries.GetProductCategoryDetails;

public class GetProductCategoryDetailsQueryValidator : AbstractValidator<GetProductCategoryDetailsQuery>
{
    public GetProductCategoryDetailsQueryValidator()
    {
        RuleFor(getProductCategoryDetailsQuery =>
            getProductCategoryDetailsQuery.Id).NotNull().NotEqual(Guid.Empty);
    }
}