using AutoMapper;
using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressDetails;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.DeliveryPoints.Queries.GetDeliveryPointDetails;

public class GetDeliveryPointDetailsQueryHandler : IRequestHandler<GetDeliveryPointDetailsQuery, DeliveryPointDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDeliveryPointDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<DeliveryPointDetailsVm> Handle(GetDeliveryPointDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DeliveryPoints
            .FirstOrDefaultAsync(deliveryPoint => 
                deliveryPoint.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(DeliveryPoint), request.Id);

        await _dbContext.DeliveryPointsAddress
            .Where(deliveryPointAddress => deliveryPointAddress.DeliveryPointId == entity.Id)
            .LoadAsync(cancellationToken);

        return _mapper.Map<DeliveryPointDetailsVm>(entity);
    }
}