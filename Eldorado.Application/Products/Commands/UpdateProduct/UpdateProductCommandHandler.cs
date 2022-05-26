using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.Products.Commands.UpdateProduct;

public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateProductCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(product => 
                product.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(Product), request.Id);

        entity.Name = request.Name;
        entity.Count = request.Count;
        entity.Price = request.Price;
        entity.Image = request.Image;
        entity.Description = request.Description;
        entity.Specifications = request.Specifications;
        entity.Producer = request.Producer;
        entity.ProductCategoryId = request.ProductCategoryId;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}