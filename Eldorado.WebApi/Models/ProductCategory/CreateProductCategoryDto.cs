using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.ProductCatigories.Commands.CreateProductCategory;

namespace Eldorado.WebApi.Models.ProductCategory;

public class CreateProductCategoryDto : IMapWith<CreateProductCategoryCommand>
{
    public string Name { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductCategoryDto, CreateProductCategoryCommand>()
            .ForMember(createProductCategoryCommand => createProductCategoryCommand.Name,
                opt =>
                    opt.MapFrom(createProductCategoryDto => createProductCategoryDto.Name));
    }
}