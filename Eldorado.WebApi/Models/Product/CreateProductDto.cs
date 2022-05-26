using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Products.Commands.CreateProduct;

namespace Eldorado.WebApi.Models.Product;

public class CreateProductDto : IMapWith<CreateProductCommand>
{
    public string Name { get; set; } = string.Empty;
    public string? Image { get; set; }
    public int Count { get; set; }
    public int Price { get; set; }
    public string Description { get; set; } = string.Empty;
    public string Specifications { get; set; } = string.Empty;
    public string Producer { get; set; } = string.Empty;
    public Guid ProductCategoryId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateProductDto, CreateProductCommand>()
            .ForMember(createProductCommand => createProductCommand.Name,
                opt =>
                    opt.MapFrom(createProductDto => createProductDto.Name))
            .ForMember(createProductCommand => createProductCommand.Image,
                opt =>
                    opt.MapFrom(createProductDto => createProductDto.Image))
            .ForMember(createProductCommand => createProductCommand.Count,
                opt =>
                    opt.MapFrom(createProductDto => createProductDto.Count))
            .ForMember(createProductCommand => createProductCommand.Price,
                opt =>
                    opt.MapFrom(createProductDto => createProductDto.Price))
            .ForMember(createProductCommand => createProductCommand.Description,
                opt =>
                    opt.MapFrom(createProductDto => createProductDto.Description))
            .ForMember(createProductCommand => createProductCommand.Specifications,
                opt =>
                    opt.MapFrom(createProductDto => createProductDto.Specifications))
            .ForMember(createProductCommand => createProductCommand.Producer,
                opt =>
                    opt.MapFrom(createProductDto => createProductDto.Producer))
            .ForMember(createProductCommand => createProductCommand.ProductCategoryId,
                opt =>
                    opt.MapFrom(createProductDto => createProductDto.ProductCategoryId));
    }
}