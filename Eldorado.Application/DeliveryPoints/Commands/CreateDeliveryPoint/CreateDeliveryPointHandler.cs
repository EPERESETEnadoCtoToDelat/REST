using AutoMapper;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;

namespace Eldorado.Application.DeliveryPoints.Commands.CreateDeliveryPoint;

public class CreateDeliveryPointHandler : IRequestHandler<CreateDeliveryPointCommand, Guid>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public CreateDeliveryPointHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<Guid> Handle(CreateDeliveryPointCommand request, CancellationToken cancellationToken)
    {
        var deliveryPoint = new DeliveryPoint
        {
            WorkingTime = request.WorkingTime,
            DeliveryPointAddress = _mapper.Map<DeliveryPointAddress>(request.DeliveryPointAddress)
        };

        await _dbContext.DeliveryPoints.AddAsync(deliveryPoint, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        return deliveryPoint.Id;
    }
}