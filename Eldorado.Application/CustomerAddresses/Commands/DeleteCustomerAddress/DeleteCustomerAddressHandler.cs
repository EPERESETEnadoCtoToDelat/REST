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

namespace Eldorado.Application.CustomerAddresses.Commands.DeleteCustomerAddress
{
    public class DeleteCustomerAddressHandler : IRequestHandler<DeleteCustomerAddressCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCustomerAddressHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.CustomersAddresses
                .FirstOrDefaultAsync(customerAddress => customerAddress.Id == request.Id);

            if (entity == null || entity.CustomerId != request.CustomerId)
            {
                throw new NotFoundException(nameof(CustomerAddress), request.Id);
            }

            _dbContext.CustomersAddresses.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
