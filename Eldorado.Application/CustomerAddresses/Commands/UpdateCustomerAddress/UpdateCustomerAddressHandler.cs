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

namespace Eldorado.Application.CustomerAddresses.Commands.UpdateCustomerAddress
{
    public class UpdateCustomerAddressHandler : IRequestHandler<UpdateCustomerAddressCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCustomerAddressHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.CustomersAddresses
                .FirstOrDefaultAsync(customerAddress => customerAddress.Id == request.Id);

            if (entity == null || entity.CustomerId != request.CustomerId)
            {
                throw new NotFoundException(nameof(CustomerAddress), request.Id);
            }

            entity.City = request.City;
            entity.Street = request.Street;
            entity.House = request.House;
            entity.Apartment = request.Apartment;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
