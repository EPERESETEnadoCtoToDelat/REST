using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.CustomerAddresses.Queries.GetCustomerAddressDetails
{
    public class CustomerAddressDetailsVm : IMapWith<CustomerAddress>
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int House { get; set; }
        public int Apartment { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CustomerAddress, CustomerAddressDetailsVm>()
                .ForMember(customerAddressVm => customerAddressVm.Id, 
                opt => opt.MapFrom(customerAddress => customerAddress.Id))
                .ForMember(customerAddressVm => customerAddressVm.CustomerId, 
                opt => opt.MapFrom(customerAddress => customerAddress.CustomerId))
                .ForMember(customerAddressVm => customerAddressVm.City,
                opt => opt.MapFrom(customerAddress => customerAddress.City))
                .ForMember(customerAddressVm => customerAddressVm.Street,
                opt => opt.MapFrom(customerAddress => customerAddress.Street))
                .ForMember(customerAddressVm => customerAddressVm.House,
                opt => opt.MapFrom(customerAddress => customerAddress.House))
                .ForMember(customerAddressVm => customerAddressVm.Apartment, 
                opt => opt.MapFrom(customerAddress => customerAddress.Apartment));
        }
    }
}
