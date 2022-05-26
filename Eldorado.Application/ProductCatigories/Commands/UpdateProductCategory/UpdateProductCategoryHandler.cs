using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.ProductCatigories.Commands.UpdateProductCategory;

public class UpdateProductCategoryHandler : IRequestHandler<UpdateProductCategoryCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateProductCategoryHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(UpdateProductCategoryCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.ProductCategories
            .FirstOrDefaultAsync(productCategory => productCategory.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(ProductCategory), request.Id);

        entity.Name = request.Name;
        
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}