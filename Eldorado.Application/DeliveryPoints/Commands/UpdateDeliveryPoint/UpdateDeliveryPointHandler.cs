using AutoMapper;
using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.DeliveryPoints.Commands.UpdateDeliveryPoint;

public class UpdateDeliveryPointHandler : IRequestHandler<UpdateDeliveryPointCommand>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public UpdateDeliveryPointHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<Unit> Handle(UpdateDeliveryPointCommand request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DeliveryPoints
            .FirstOrDefaultAsync(deliveryPoint => 
                deliveryPoint.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(DeliveryPointAddress), request.Id);
        
        await _dbContext.DeliveryPointsAddress
            .Where(deliveryPointAddress => deliveryPointAddress.DeliveryPointId == request.Id)
            .LoadAsync(cancellationToken);
        
        entity.WorkingTime = request.WorkingTime;
        entity.DeliveryPointAddress.City = request.DeliveryPointAddressCommand.City;
        entity.DeliveryPointAddress.House = request.DeliveryPointAddressCommand.House;
        entity.DeliveryPointAddress.Street = request.DeliveryPointAddressCommand.Street;
        await _dbContext.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}
