using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.SelectedProducts;

namespace Eldorado.WebApi.Models.Order;

public class SelectedProductDto : IMapWith<SelectedProductHelper>
{
    public Guid ProductId { get; set; }
    public int Count { get; set; }
    

    public void Mapping(Profile profile)
    {
        profile.CreateMap<SelectedProductDto, SelectedProductHelper>()
            .ForMember(selectedProduct => selectedProduct.ProductId,
                opt =>
                    opt.MapFrom(selectedProductDto => selectedProductDto.ProductId))
            .ForMember(selectedProduct => selectedProduct.Count,
                opt =>
                    opt.MapFrom(selectedProductDto => selectedProductDto.Count));
    }
}