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

namespace Eldorado.Application.Customers.Queries.GetCustomerList
{
    public class GetCustomerListQueryHandler : IRequestHandler<GetCustomerListQuery, CustomerListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCustomerListQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CustomerListVm> Handle(GetCustomerListQuery request, CancellationToken cancellationToken)
        {
            var customersQuery = await _dbContext.Customers
                .ProjectTo<CustomerLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CustomerListVm { Customers = customersQuery };
        }
    }
}
