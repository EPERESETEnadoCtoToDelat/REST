using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eldorado.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressList;

public class GetDeliveryPointAddressListQueryHandler : IRequestHandler<GetDeliveryPointAddressListQuery, DeliveryPointAddressListVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDeliveryPointAddressListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<DeliveryPointAddressListVm> Handle(GetDeliveryPointAddressListQuery request, CancellationToken cancellationToken)
    {
        var deliveryPointAddressesQuery = await _dbContext.DeliveryPointsAddress
            .ProjectTo<DeliveryPointAddressLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new DeliveryPointAddressListVm { DeliveryPointAddresses = deliveryPointAddressesQuery };
    }
}