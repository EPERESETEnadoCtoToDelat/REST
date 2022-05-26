using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.DeliveryPoints.Commands.DeleteDeliveryPoint;

public class DeleteDeliveryPointHandler : IRequestHandler<DeleteDeliveryPointCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteDeliveryPointHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(DeleteDeliveryPointCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DeliveryPoints
            .FirstOrDefaultAsync(deliveryPointAddress =>
                deliveryPointAddress.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(DeliveryPoint), request.Id);

        _dbContext.DeliveryPoints.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}