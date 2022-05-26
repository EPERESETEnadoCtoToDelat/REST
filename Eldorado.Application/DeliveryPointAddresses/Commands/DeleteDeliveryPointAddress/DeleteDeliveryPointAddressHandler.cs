using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.DeleteDeliveryPointAddress;

public class DeleteDeliveryPointAddressHandler : IRequestHandler<DeleteDeliveryPointAddressCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public DeleteDeliveryPointAddressHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(DeleteDeliveryPointAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DeliveryPointsAddress
            .FirstOrDefaultAsync(deliveryPointAddress => 
                deliveryPointAddress.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(DeliveryPointAddresses), request.Id);

        _dbContext.DeliveryPointsAddress.Remove(entity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}