using Eldorado.Application.SelectedProducts;
using Eldorado.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public Guid? DeliveryPointId { get; set; }
        public IList<SelectedProductHelper>? SelectedProducts { get; set; }
        public int Price { get; set; }
        public Guid CustomerId { get; set; }
        public Guid? CourierId { get; set; }
    }
}
