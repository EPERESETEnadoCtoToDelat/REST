using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eldorado.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.DeliveryPoints.Queries.GetDeliveryPointList;

public class GetDeliveryPointListQueryHandler : IRequestHandler<GetDeliveryPointListQuery, DeliveryPointListVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetDeliveryPointListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<DeliveryPointListVm> Handle(GetDeliveryPointListQuery request, CancellationToken cancellationToken)
    {
        var deliveryPointsQuery = await _dbContext.DeliveryPoints
            .ProjectTo<DeliveryPointLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new DeliveryPointListVm { DeliveryPoints = deliveryPointsQuery };
    }
}