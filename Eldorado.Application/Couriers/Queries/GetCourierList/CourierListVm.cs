using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Queries.GetCourierList
{
    public class CourierListVm
    {
        public IList<CourierLookupDto>? Couriers { get; set; }
    }
}
