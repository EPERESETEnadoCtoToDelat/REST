using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.ProductCatigories.Queries.GetProductCategoryDetails;

public class ProductCategoryDetailsVm : IMapWith<ProductCategory>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductCategory, ProductCategoryDetailsVm>()
            .ForMember(productCategoryDetailsVm => productCategoryDetailsVm.Id,
                opt =>
                    opt.MapFrom(productCategory => productCategory.Id))
            .ForMember(productCategoryDetailsVm => productCategoryDetailsVm.Name,
                opt =>
                    opt.MapFrom(productCategory => productCategory.Name));
    }
}