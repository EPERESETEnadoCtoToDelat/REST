using FluentValidation;
using MediatR;

namespace Eldorado.Application.Products.Queries.GetProductList;

public class GetProductListQueryValidator : AbstractValidator<GetProductListQuery>
{
    public GetProductListQueryValidator()
    {
        
    }
}