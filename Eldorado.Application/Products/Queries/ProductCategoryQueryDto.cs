using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Products.Queries;

public class ProductCategoryQueryDto : IMapWith<ProductCategory>
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<ProductCategory, ProductCategoryQueryDto>()
            .ForMember(productCategoryQueryDto => productCategoryQueryDto.Id,
                opt =>
                    opt.MapFrom(productCategory => productCategory.Id))
            .ForMember(productCategoryQueryDto => productCategoryQueryDto.Name,
                opt =>
                    opt.MapFrom(productCategory => productCategory.Name));
    }
    
}