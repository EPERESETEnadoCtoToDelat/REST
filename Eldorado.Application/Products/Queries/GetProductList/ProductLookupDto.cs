using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Products.Queries.GetProductList;

public class ProductLookupDto : IMapWith<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public ProductCategoryQueryDto ProductCategory { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductLookupDto>()
            .ForMember(productLookupDto => productLookupDto.Id,
                opt =>
                    opt.MapFrom(product => product.Id))
            .ForMember(productLookupDto => productLookupDto.Name,
                opt =>
                    opt.MapFrom(product => product.Name))
            .ForMember(productLookupDto => productLookupDto.Image,
                opt =>
                    opt.MapFrom(product => product.Image))
            .ForMember(productLookupDto => productLookupDto.Count,
                opt =>
                    opt.MapFrom(product => product.Count))
            .ForMember(productLookupDto => productLookupDto.Price,
                opt =>
                    opt.MapFrom(product => product.Price))
            .ForMember(productLookupDto => productLookupDto.Description,
                opt =>
                    opt.MapFrom(product => product.Description))
            .ForMember(productLookupDto => productLookupDto.Specifications,
                opt =>
                    opt.MapFrom(product => product.Specifications))
            .ForMember(productLookupDto => productLookupDto.Producer,
                opt =>
                    opt.MapFrom(product => product.Producer))
            .ForMember(productLookupDto => productLookupDto.ProductCategory,
                opt =>
                    opt.MapFrom(product => product.ProductCategory));;
    }
}