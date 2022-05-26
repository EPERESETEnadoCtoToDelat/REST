using FluentValidation;

namespace Eldorado.Application.ProductCatigories.Commands.DeleteProductCategory;

public class DeleteProductCategoryCommandValidator : AbstractValidator<DeleteProductCategoryCommand>
{
    public DeleteProductCategoryCommandValidator()
    {
        RuleFor(deleteProductCategoryCommand =>
            deleteProductCategoryCommand.Id).NotNull().NotEqual(Guid.Empty);
    }
}