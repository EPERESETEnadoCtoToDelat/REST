using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Commands.CreateCustomerAddress
{
    public class CreateCustomerAddressHandler : IRequestHandler<CreateCustomerAddressCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;

        public CreateCustomerAddressHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCustomerAddressCommand request, CancellationToken cancellationToken)
        {
            var customerAddress = new CustomerAddress
            {
                City = request.City,
                Street = request.Street,
                House = request.House,
                Apartment = request.Apartment,
                CustomerId = request.CustomerId,
            };

            await _dbContext.CustomersAddresses.AddAsync(customerAddress, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return customerAddress.Id;
        }
    }
}
