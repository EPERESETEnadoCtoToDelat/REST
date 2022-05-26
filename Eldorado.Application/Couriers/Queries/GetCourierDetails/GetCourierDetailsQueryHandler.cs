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

namespace Eldorado.Application.Couriers.Queries.GetCourierDetails
{
    public class GetCourierDetailsQueryHandler : IRequestHandler<GetCourierDetailsQuery, CourierDetailsVm>
    {
        private readonly IApplicationDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCourierDetailsQueryHandler(IApplicationDbContext dbContext, IMapper mapper) =>
            (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CourierDetailsVm> Handle(GetCourierDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Couriers
                .FirstOrDefaultAsync(courier => courier.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Courier), request.Id);
            }

            return _mapper.Map<CourierDetailsVm>(entity);
        }
    }
}
