using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.ProductCatigories.Commands.UpdateProductCategory;

namespace Eldorado.WebApi.Models.ProductCategory;

public class UpdateProductCategoryDto : IMapWith<UpdateProductCategoryCommand>
{
    public Guid Id { get; set; }
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateProductCategoryDto, UpdateProductCategoryCommand>()
            .ForMember(updateProductCategoryCommand => updateProductCategoryCommand.Id,
                opt =>
                    opt.MapFrom(updateProductCategoryDto => updateProductCategoryDto.Id))
            .ForMember(updateProductCategoryCommand => updateProductCategoryCommand.Name,
                opt =>
                    opt.MapFrom(updateProductCategoryDto => updateProductCategoryDto.Name));
    }
}