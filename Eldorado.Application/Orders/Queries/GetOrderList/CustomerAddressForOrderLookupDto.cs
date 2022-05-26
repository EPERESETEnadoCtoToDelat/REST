using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Orders.Queries.GetOrderList;

public class CustomerAddressForOrderLookupDto : IMapWith<CustomerAddress>
{
    public Guid Id { get; set; }
    public string City { get; set; } = string.Empty;
    public string Street { get; set; } = string.Empty;
    public int House { get; set; }
    public int Apartment { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CustomerAddress, CustomerAddressForOrderLookupDto>()
            .ForMember(customerAddressLookupDto => customerAddressLookupDto.Id,
                opt =>
                    opt.MapFrom(customerAddress => customerAddress.Id))
            .ForMember(customerAddressLookupDto => customerAddressLookupDto.City,
                opt =>
                    opt.MapFrom(customerAddress => customerAddress.City))
            .ForMember(customerAddressLookupDto => customerAddressLookupDto.Street,
                opt =>
                    opt.MapFrom(customerAddress => customerAddress.Street))
            .ForMember(customerAddressLookupDto => customerAddressLookupDto.House,
                opt =>
                    opt.MapFrom(customerAddress => customerAddress.House))
            .ForMember(customerAddressLookupDto => customerAddressLookupDto.Apartment,
                opt =>
                    opt.MapFrom(customerAddress => customerAddress.Apartment));
    }
}