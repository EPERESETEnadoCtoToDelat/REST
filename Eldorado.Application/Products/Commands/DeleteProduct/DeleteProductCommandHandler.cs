using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.Products.Commands.DeleteProduct;

public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteProductCommandHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.Products
            .FirstOrDefaultAsync(product => 
                product.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(Product), request.Id);

        _dbContext.Products.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}