using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Orders.Queries.GetOrderDetails;

public class SelectedProductQueryDto : IMapWith<SelectedProduct>
{
    public Guid Id { get; set; }
    public int Count { get; set; }
    public ProductInOrderDto Product { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<SelectedProduct, SelectedProductQueryDto>()
            .ForMember(selectedProductDto => selectedProductDto.Id,
                opt =>
                    opt.MapFrom(selectedProduct => selectedProduct.Id))
            .ForMember(selectedProductDto => selectedProductDto.Product,
                opt =>
                    opt.MapFrom(selectedProduct => selectedProduct.Product))
            .ForMember(selectedProductDto => selectedProductDto.Count,
                opt =>
                    opt.MapFrom(selectedProduct => selectedProduct.Count));
    }
}