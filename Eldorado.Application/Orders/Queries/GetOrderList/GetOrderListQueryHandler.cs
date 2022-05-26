using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eldorado.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.Orders.Queries.GetOrderList;

public class GetOrderListQueryHandler : IRequestHandler<GetOrderListQuery, OrderListVm>
{
    private readonly IApplicationDbContext _dbContext;
    private readonly IMapper _mapper;

    public GetOrderListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
        (_dbContext, _mapper) = (dbContext, mapper);
    
    public async Task<OrderListVm> Handle(GetOrderListQuery request, CancellationToken cancellationToken)
    {
        var ordersQuery = await _dbContext.Orders
            .ProjectTo<OrderLookupDto>(_mapper.ConfigurationProvider)
            .ToListAsync(cancellationToken);

        return new OrderListVm { Orders = ordersQuery };
    }
}