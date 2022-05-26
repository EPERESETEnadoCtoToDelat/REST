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

namespace Eldorado.Application.CustomerAddresses.Queries.GetCustomerAddressDetails
{
    public class GetCustomerAddressDetailsQueryHandler : IRequestHandler<GetCustomerAddressDetailsQuery, CustomerAddressDetailsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerAddressDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CustomerAddressDetailsVm> Handle(GetCustomerAddressDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.CustomersAddresses
                .FirstOrDefaultAsync(customerAddress => customerAddress.CustomerId == request.CustomerId, cancellationToken);

            if(entity == null || entity.CustomerId != request.CustomerId)
            {
                throw new NotFoundException(nameof(CustomerAddress), request.CustomerId);
            }

            return _mapper.Map<CustomerAddressDetailsVm>(entity);
        }
    }
}
