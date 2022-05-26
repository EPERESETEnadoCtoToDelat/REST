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

namespace Eldorado.Application.Couriers.Commands.DeleteCourier
{
    public class DeleteCourierHandler : IRequestHandler<DeleteCourierCommand>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteCourierHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteCourierCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Couriers
                .FirstOrDefaultAsync(courier => courier.Id == request.Id, cancellationToken);

            if(entity == null)
            {
                throw new NotFoundException(nameof(Courier), request.Id);
            }

            _dbContext.Couriers.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
