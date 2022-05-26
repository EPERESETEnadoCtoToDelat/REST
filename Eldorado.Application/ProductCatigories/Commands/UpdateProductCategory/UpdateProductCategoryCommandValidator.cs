using FluentValidation;

namespace Eldorado.Application.ProductCatigories.Commands.UpdateProductCategory;

public class UpdateProductCategoryCommandValidator : AbstractValidator<UpdateProductCategoryCommand>
{
    public UpdateProductCategoryCommandValidator()
    {
        RuleFor(updateProductCategoryCommand =>
            updateProductCategoryCommand.Id).NotNull().NotEqual(Guid.Empty);
        RuleFor(updateProductCategoryCommand =>
            updateProductCategoryCommand.Name).NotNull().NotEqual(string.Empty);
    }
}