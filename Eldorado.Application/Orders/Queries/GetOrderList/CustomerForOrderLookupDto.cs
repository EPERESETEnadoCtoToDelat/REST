using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Orders.Queries.GetOrderList;

public class CustomerForOrderLookupDto : IMapWith<Customer>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string? FullName { get; set; } = string.Empty;
    public int Age { get; set; }
    public string Phone { get; set; } = string.Empty;
    public string? Email { get; set; }
    public CustomerAddressForOrderLookupDto? CustomerAddress { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Customer, CustomerForOrderLookupDto>()
            .ForMember(customerLookupDto => customerLookupDto.Id,
                opt =>
                    opt.MapFrom(customer => customer.Id))
            .ForMember(customerLookupDto => customerLookupDto.FirstName,
                opt =>
                    opt.MapFrom(customer => customer.FirstName))
            .ForMember(customerLookupDto => customerLookupDto.LastName,
                opt =>
                    opt.MapFrom(customer => customer.LastName))
            .ForMember(customerLookupDto => customerLookupDto.FullName,
                opt =>
                    opt.MapFrom(customer => customer.FullName))
            .ForMember(customerLookupDto => customerLookupDto.Age,
                opt =>
                    opt.MapFrom(customer => customer.Age))
            .ForMember(customerLookupDto => customerLookupDto.Phone,
                opt =>
                    opt.MapFrom(customer => customer.Phone))
            .ForMember(customerLookupDto => customerLookupDto.Email,
                opt =>
                    opt.MapFrom(customer => customer.Email))
            .ForMember(customerLookupDto => customerLookupDto.CustomerAddress,
                opt =>
                    opt.MapFrom(customer => customer.CustomerAddress));
    }
}