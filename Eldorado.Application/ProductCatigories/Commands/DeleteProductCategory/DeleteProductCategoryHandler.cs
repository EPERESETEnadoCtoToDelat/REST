using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.ProductCatigories.Commands.DeleteProductCategory;

public class DeleteProductCategoryHandler : IRequestHandler<DeleteProductCategoryCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteProductCategoryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(DeleteProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ProductCategories
            .FirstOrDefaultAsync(productCategory =>
                productCategory.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(ProductCategory), request.Id);

        _dbContext.ProductCategories.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}