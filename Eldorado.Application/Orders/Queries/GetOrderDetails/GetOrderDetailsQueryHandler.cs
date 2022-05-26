using AutoMapper;
using Eldorado.Application.Common.Exceptions;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;

namespace Eldorado.Application.Orders.Queries.GetOrderDetails
{
    public class GetOrderDetailsQueryHandler : IRequestHandler<GetOrderDetailsQuery, OrderDetailsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetOrderDetailsQueryHandler(IMapper mapper, IApplicationDbContext dbContext) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<OrderDetailsVm> Handle(GetOrderDetailsQuery request, CancellationToken cancellationToken)
        {
            var orderDetailsQuery = await _dbContext.Orders
                .Where(order => order.Id == request.Id && order.CustomerId == request.CustomerId)
                .ProjectTo<OrderDetailsVm>(_mapper.ConfigurationProvider)
                .FirstAsync(cancellationToken);
                //.FirstOrDefaultAsync(order => order.Id == request.Id, cancellationToken);

            if(orderDetailsQuery == null || orderDetailsQuery.Id != request.Id)
                throw new NotFoundException(nameof(Order), request.Id);

            /*var selectedProducts = await _dbContext.SelectedProducts
                .Where(selectedProduct => selectedProduct.OrderId == request.Id)
                .ProjectTo<SelectedProductQueryDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);*/

            /*return new OrderAndSelectedProductVm
                { OrderDetails = orderDetailsQuery, SelectedProducts = selectedProducts };*/
            return orderDetailsQuery;

            /*order.DeliveryPoint = _mapper
                .Map<DeliveryPointDto>(await _dbContext.DeliveryPoints
                .FirstOrDefaultAsync(deliveryPoint => deliveryPoint.Id == entity.DeliveryPointId, cancellationToken));*/

            /*order.DeliveryPoint.DeliveryPointAddress = _mapper
                .Map<DeliveryPointAddressDto>(await _dbContext.DeliveryPointsAddress
                .FirstOrDefaultAsync(deliveryPointAddress => deliveryPointAddress.DeliveryPointId == entity.DeliveryPointId));

            order.Customer = _mapper
                .Map<CustomerDto>(await _dbContext.Customers
                .FirstOrDefaultAsync(customer => customer.Id == entity.CustomerId));

            order.Customer.CustomerAddress = _mapper
                .Map<CustomerAddressDto>(await _dbContext.CustomersAddresses
                .FirstOrDefaultAsync(customerAddress => customerAddress.CustomerId == entity.CustomerId));*/

            /*order.Courier = _mapper
                .Map<CourierDto>(await _dbContext.Couriers
                .FirstOrDefaultAsync(courier => courier.Id == entity.CourierId, cancellationToken));*/

            //return order;
        }
    }
}
