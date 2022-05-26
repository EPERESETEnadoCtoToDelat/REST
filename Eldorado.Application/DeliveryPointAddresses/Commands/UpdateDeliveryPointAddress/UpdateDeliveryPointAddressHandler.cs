using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.DeliveryPointAddresses.Commands.UpdateDeliveryPointAddress;

public class UpdateDeliveryPointAddressHandler : IRequestHandler<UpdateDeliveryPointAddressCommand>
{
    private readonly IApplicationDbContext _dbContext;

    public UpdateDeliveryPointAddressHandler(IApplicationDbContext dbContext) =>
        _dbContext = dbContext;
    
    public async Task<Unit> Handle(UpdateDeliveryPointAddressCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DeliveryPointsAddress.
            FirstOrDefaultAsync(deliveryPointAddress =>
                deliveryPointAddress.Id == request.Id, cancellationToken);
        
        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(DeliveryPointAddresses), request.Id);

        entity.City = request.City;
        entity.House = request.House;
        entity.Street = request.Street;

        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}