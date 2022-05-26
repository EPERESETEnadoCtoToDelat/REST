using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Orders.Queries.GetOrderList;

public class SelectedProductLookupDto : IMapWith<SelectedProduct>
{
    public Guid Id { get; set; }
    public int Count { get; set; }
    public ProductInOrderLookupDto Product { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<SelectedProduct, SelectedProductLookupDto>()
            .ForMember(selectedProductLookupDto => selectedProductLookupDto.Id,
                opt =>
                    opt.MapFrom(selectedProduct => selectedProduct.Id))
            .ForMember(selectedProductLookupDto => selectedProductLookupDto.Count,
                opt =>
                    opt.MapFrom(selectedProduct => selectedProduct.Count))
            .ForMember(selectedProductLookupDto => selectedProductLookupDto.Product,
                opt =>
                    opt.MapFrom(selectedProduct => selectedProduct.Product));
    }
}