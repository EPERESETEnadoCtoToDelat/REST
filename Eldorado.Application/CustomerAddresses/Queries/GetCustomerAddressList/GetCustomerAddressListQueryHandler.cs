using AutoMapper;
using AutoMapper.QueryableExtensions;
using Eldorado.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Queries.GetCustomerAddressList
{
    public class GetCustomerAddressListQueryHandler : IRequestHandler<GetCustomerAddressListQuery, CustomerAddressListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerAddressListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CustomerAddressListVm> Handle(GetCustomerAddressListQuery request, CancellationToken cancellationToken)
        {
            var customerAddressesQuery = await _dbContext.CustomersAddresses
                .ProjectTo<CustomerAddressLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CustomerAddressListVm { CustomerAddresses = customerAddressesQuery };
        }
    }
}
