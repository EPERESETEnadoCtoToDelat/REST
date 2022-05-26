using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Commands.DeleteCourier
{
    public class DeleteCourierCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
