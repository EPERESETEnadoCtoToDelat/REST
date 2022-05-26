using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Products.Queries.GetProductDetails;

public class ProductDetailsVm : IMapWith<Product>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public string ProductCategory { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Product, ProductDetailsVm>()
            .ForMember(productDetailsVm => productDetailsVm.Id,
                opt =>
                    opt.MapFrom(product => product.Id))
            .ForMember(productDetailsVm => productDetailsVm.Name,
                opt =>
                    opt.MapFrom(product => product.Name))
            .ForMember(productDetailsVm => productDetailsVm.Image,
                opt =>
                    opt.MapFrom(product => product.Image))
            .ForMember(productDetailsVm => productDetailsVm.Count,
                opt =>
                    opt.MapFrom(product => product.Count))
            .ForMember(productDetailsVm => productDetailsVm.Price,
                opt =>
                    opt.MapFrom(product => product.Price))
            .ForMember(productDetailsVm => productDetailsVm.Description,
                opt =>
                    opt.MapFrom(product => product.Description))
            .ForMember(productDetailsVm => productDetailsVm.Specifications,
                opt =>
                    opt.MapFrom(product => product.Specifications))
            .ForMember(productDetailsVm => productDetailsVm.Producer,
                opt =>
                    opt.MapFrom(product => product.Producer));
    }
}