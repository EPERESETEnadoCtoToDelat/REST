using FluentValidation;

namespace Eldorado.Application.Products.Commands.CreateProduct;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(createProductCommand => 
            createProductCommand.Name).NotNull().NotEqual(string.Empty);
        RuleFor(createProductCommand =>
            createProductCommand.Producer).NotNull().NotEqual(string.Empty);
        RuleFor(createProductCommand =>
            createProductCommand.Producer).NotNull().NotEqual(string.Empty);
        RuleFor(createProductCommand =>
            createProductCommand.Specifications).NotNull().NotEqual(string.Empty);
        RuleFor(createProductCommand =>
            createProductCommand.ProductCategoryId).NotNull().NotEqual(Guid.Empty);
    }
}