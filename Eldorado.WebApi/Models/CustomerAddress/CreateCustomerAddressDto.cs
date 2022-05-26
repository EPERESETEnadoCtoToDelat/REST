using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.CustomerAddresses.Commands.CreateCustomerAddress;

namespace Eldorado.WebApi.Models.CustomerAddress
{
    public class CreateCustomerAddressDto : IMapWith<CreateCustomerAddressCommand>
    {
        public string City { get; set; } = string.Empty;
        public string Street { get; set; } = string.Empty;
        public int House { get; set; }
        public int Apartment { get; set; }
        public Guid CustomerId { get; set; }
        
        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCustomerAddressDto, CreateCustomerAddressCommand>()
                .ForMember(customerAddressCommand => customerAddressCommand.City, 
                opt => opt.MapFrom(customerAddressDto => customerAddressDto.City))
                .ForMember(customerAddressCommand => customerAddressCommand.Street, 
                opt => opt.MapFrom(customerAddressDto => customerAddressDto.Street))
                .ForMember(customerAddressCommand => customerAddressCommand.House,
                opt => opt.MapFrom(customerAddressDto => customerAddressDto.House))
                .ForMember(customerAddressCommand => customerAddressCommand.Apartment,
                opt => opt.MapFrom(customerAddressDto => customerAddressDto.Apartment ))
                .ForMember(customerAddressCommand => customerAddressCommand.CustomerId,
                opt => opt.MapFrom(customerAddressDto => customerAddressDto.CustomerId));
        }
    }
}
