using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Commands.CreateCourier
{
    public class CreateCourierHandler : IRequestHandler<CreateCourierCommand, Guid>
    {
        private readonly IApplicationDbContext _dbContext;
        
        public CreateCourierHandler(IApplicationDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CreateCourierCommand request, CancellationToken cancellationToken)
        {
            var courier = new Courier
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                PassportNumber = request.PassportNumber,
                Phone = request.Phone,
                Age = request.Age
            };

            await _dbContext.Couriers.AddAsync(courier, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return courier.Id;
        }
    }
}
