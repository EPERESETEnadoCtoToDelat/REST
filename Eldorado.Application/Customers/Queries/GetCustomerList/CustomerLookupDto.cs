using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Customers.Queries.GetCustomerList
{
    public class CustomerLookupDto : IMapWith<Customer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerLookupDto>()
                .ForMember(customerVm => customerVm.FirstName,
                    opt => opt.MapFrom(customer => customer.FirstName))
                .ForMember(customerVm => customerVm.LastName,
                    opt => opt.MapFrom(customer => customer.LastName))
                .ForMember(customerVm => customerVm.Age,
                    opt => opt.MapFrom(customer => customer.Age))
                .ForMember(customerVm => customerVm.Phone,
                    opt => opt.MapFrom(customer => customer.Phone))
                .ForMember(customerVm => customerVm.Email,
                    opt => opt.MapFrom(customer => customer.Email));
        }
    }
}
