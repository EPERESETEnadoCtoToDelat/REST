using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Orders.Queries.GetOrderDetails;

public class ProductInOrderDto : IMapWith<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public int Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductInOrderDto>()
            .ForMember(productInOrderDto => productInOrderDto.Id,
                opt =>
                    opt.MapFrom(product => product.Id))
            .ForMember(productInOrderDto => productInOrderDto.Name,
                opt =>
                    opt.MapFrom(product => product.Name))
            .ForMember(productInOrderDto => productInOrderDto.Price,
                opt =>
                    opt.MapFrom(product => product.Price))
            .ForMember(productInOrderDto => productInOrderDto.Description,
                opt =>
                    opt.MapFrom(product => product.Description))
            .ForMember(productInOrderDto => productInOrderDto.Specifications,
                opt =>
                    opt.MapFrom(product => product.Specifications))
            .ForMember(productInOrderDto => productInOrderDto.Producer,
                opt =>
                    opt.MapFrom(product => product.Producer));
    }
}