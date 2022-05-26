using AutoMapper;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Eldorado.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            List<SelectedProduct> selectedProducts = _mapper.Map<List<SelectedProduct>>(request.SelectedProducts);

            Order order = new Order
            {
                Date = DateTime.Now,
                DeliveryPointId = request.DeliveryPointId,
                Price = request.Price,
                CustomerId = request.CustomerId,
                CourierId = request.CourierId,
                SelectedProducts = selectedProducts
            };

            await _dbContext.Orders.AddAsync(order, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return order.Id;
        }
    }
}
