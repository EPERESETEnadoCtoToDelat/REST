using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Products.Commands.CreateProduct;
using Eldorado.Application.Products.Commands.UpdateProduct;

namespace Eldorado.WebApi.Models.Product;

public class UpdateProductDto : IMapWith<UpdateProductCommand>
{
    public Guid Id { get; set; }
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
        profile.CreateMap<UpdateProductDto, UpdateProductCommand>()
            .ForMember(updateProductCommand => updateProductCommand.Id,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.Id))
            .ForMember(updateProductCommand => updateProductCommand.Name,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.Name))
            .ForMember(updateProductCommand => updateProductCommand.Image,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.Image))
            .ForMember(updateProductCommand => updateProductCommand.Count,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.Count))
            .ForMember(updateProductCommand => updateProductCommand.Price,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.Price))
            .ForMember(updateProductCommand => updateProductCommand.Description,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.Description))
            .ForMember(updateProductCommand => updateProductCommand.Specifications,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.Specifications))
            .ForMember(updateProductCommand => updateProductCommand.Producer,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.Producer))
            .ForMember(updateProductCommand => updateProductCommand.ProductCategoryId,
                opt =>
                    opt.MapFrom(updateProductDto => updateProductDto.ProductCategoryId));
    }
}