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

namespace Eldorado.Application.Couriers.Queries.GetCourierList
{
    public class GetCourierListQuertHandler : IRequestHandler<GetCourierListQuery, CourierListVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCourierListQuertHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CourierListVm> Handle(GetCourierListQuery request, CancellationToken cancellationToken)
        {
            var couriersQuery = await _dbContext.Couriers
                .ProjectTo<CourierLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CourierListVm { Couriers = couriersQuery };
        }
    }
}
