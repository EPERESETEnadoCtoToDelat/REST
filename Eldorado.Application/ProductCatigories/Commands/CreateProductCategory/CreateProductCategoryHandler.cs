using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;

namespace Eldorado.Application.ProductCatigories.Commands.CreateProductCategory;

public class CreateProductCategoryHandler : IRequestHandler<CreateProductCategoryCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;

    public CreateProductCategoryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Guid> Handle(CreateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        ProductCategory productCategory = new ProductCategory
        {
            Name = request.Name
        };

        await _dbContext.ProductCategories.AddAsync(productCategory, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return productCategory.Id;
    }
}