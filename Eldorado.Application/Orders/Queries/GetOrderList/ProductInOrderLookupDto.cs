using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Orders.Queries.GetOrderList;

public class ProductInOrderLookupDto : IMapWith<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductInOrderLookupDto>()
            .ForMember(productInOrderLookupDto => productInOrderLookupDto.Id,
                opt =>
                    opt.MapFrom(product => product.Id))
            .ForMember(productInOrderLookupDto => productInOrderLookupDto.Name,
                opt =>
                    opt.MapFrom(product => product.Name))
            .ForMember(productInOrderLookupDto => productInOrderLookupDto.Price,
                opt =>
                    opt.MapFrom(product => product.Price))
            .ForMember(productInOrderLookupDto => productInOrderLookupDto.Description,
                opt =>
                    opt.MapFrom(product => product.Description))
            .ForMember(productInOrderLookupDto => productInOrderLookupDto.Specifications,
                opt =>
                    opt.MapFrom(product => product.Specifications))
            .ForMember(productInOrderLookupDto => productInOrderLookupDto.Producer,
                opt =>
                    opt.MapFrom(product => product.Producer));
    }
}