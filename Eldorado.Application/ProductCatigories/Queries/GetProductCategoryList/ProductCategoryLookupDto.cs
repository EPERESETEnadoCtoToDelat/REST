using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.ProductCatigories.Queries.GetProductCategoryList;

public class ProductCategoryLookupDto : IMapWith<ProductCategory>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductCategory, ProductCategoryLookupDto>()
            .ForMember(productCategoryLookupDto => productCategoryLookupDto.Id,
                opt =>
                    opt.MapFrom(productCategory => productCategory.Id))
            .ForMember(productCategoryLookupDto => productCategoryLookupDto.Name,
                opt =>
                    opt.MapFrom(productCategory => productCategory.Name));
    }
}