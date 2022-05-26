using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Customers.Queries.GetCustomerDetails
{
    public class CustomerDetailsVm : IMapWith<Customer>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Customer, CustomerDetailsVm>()
                .ForMember(customerDto => customerDto.Id,
                    opt => opt.MapFrom(customer => customer.Id))
                .ForMember(customerDto => customerDto.FirstName,
                    opt => opt.MapFrom(customer => customer.FirstName))
                .ForMember(customerDto => customerDto.LastName,
                    opt => opt.MapFrom(customer => customer.LastName))
                .ForMember(customerDto => customerDto.Age,
                    opt => opt.MapFrom(customer => customer.Age))
                .ForMember(customerDto => customerDto.Phone,
                    opt => opt.MapFrom(customer => customer.Phone))
                .ForMember(customerDto => customerDto.Email,
                    opt => opt.MapFrom(customer => customer.Email));
        }  
    }
}
