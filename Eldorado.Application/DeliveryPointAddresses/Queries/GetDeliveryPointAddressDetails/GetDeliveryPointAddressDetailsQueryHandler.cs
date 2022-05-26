using AutoMapper;
using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressDetails;

public class GetDeliveryPointAddressDetailsQueryHandler : IRequestHandler<GetDeliveryPointAddressDetailsQuery, DeliveryPointAddressDetailsVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDeliveryPointAddressDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public  async Task<DeliveryPointAddressDetailsVm> Handle(GetDeliveryPointAddressDetailsQuery request, CancellationToken cancellationToken)
    {
        var entity = await _dbContext.DeliveryPointsAddress
            .FirstOrDefaultAsync(deliveryPointAddress =>
                deliveryPointAddress.Id == request.Id, cancellationToken);

        if (entity == null || entity.Id != request.Id)
            throw new NotFoundException(nameof(DeliveryPointAddress), request.Id);

        return _mapper.Map<DeliveryPointAddressDetailsVm>(entity);
    }
}