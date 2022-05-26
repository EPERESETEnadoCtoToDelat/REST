using FluentValidation;

namespace Eldorado.Application.ProductCatigories.Commands.CreateProductCategory;

public class CreateProductCategoryCommandValidator : AbstractValidator<CreateProductCategoryCommand>
{
    public CreateProductCategoryCommandValidator()
    {
        RuleFor(createProductCategoryCommand =>
            createProductCategoryCommand.Name).NotNull().NotEqual(string.Empty);
    }
}