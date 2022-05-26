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

namespace Eldorado.Application.Couriers.Commands.UpdateCourier
{
    public class UpdateCourierHandler : IRequestHandler<UpdateCourierCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public UpdateCourierHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateCourierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Couriers
                .FirstOrDefaultAsync(courier => courier.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Courier), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Phone = request.Phone;
            entity.Age  = request.Age;
            entity.PassportNumber = request.PassportNumber;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
