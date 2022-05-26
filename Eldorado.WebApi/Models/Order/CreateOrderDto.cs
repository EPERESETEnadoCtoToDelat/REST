using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Orders.Commands.CreateOrder;

namespace Eldorado.WebApi.Models.Order;

public class CreateOrderDto : IMapWith<CreateOrderCommand>
{
    public Guid? DeliveryPointId { get; set; }
    public IList<SelectedProductDto>? SelectedProducts { get; set; }
    public int Price { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? CourierId { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateOrderDto, CreateOrderCommand>()
            .ForMember(createOrderCommand => createOrderCommand.DeliveryPointId,
                opt =>
                    opt.MapFrom(createOrderDto => createOrderDto.DeliveryPointId))
            .ForMember(createOrderCommand => createOrderCommand.SelectedProducts,
                opt =>
                    opt.MapFrom(createOrderDto => createOrderDto.SelectedProducts))
            .ForMember(createOrderCommand => createOrderCommand.Price,
                opt =>
                    opt.MapFrom(createOrderDto => createOrderDto.Price))
            .ForMember(createOrderCommand => createOrderCommand.CustomerId,
                opt =>
                    opt.MapFrom(createOrderDto => createOrderDto.CustomerId))
            .ForMember(createOrderCommand => createOrderCommand.CourierId,
                opt =>
                    opt.MapFrom(createOrderDto => createOrderDto.CourierId));
    }
}