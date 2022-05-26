using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Orders.Queries.GetOrderDetails;
using Eldorado.Domain;

namespace Eldorado.Application.Orders.Queries.GetOrderList;

public class OrderLookupDto : IMapWith<Order>
{
    public Guid Id { get; set; }
    public DateTime Date { get; set; }
    public int Price { get; set; }
    public List<SelectedProductQueryDto> SelectedProducts { get; set; } = null!;
    public CourierForOrderLookupDto? Courier { get; set; }
    //public DeliveryPointQueryDto? DeliveryPoint { get; set; }
    public CustomerDto? Customer { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Order, OrderLookupDto>()
            .ForMember(orderLookupDto => orderLookupDto.Id,
                opt =>
                    opt.MapFrom(order => order.Id))
            .ForMember(orderLookupDto => orderLookupDto.Date,
                opt =>
                    opt.MapFrom(order => order.Date))
            .ForMember(orderLookupDto => orderLookupDto.Price,
                opt =>
                    opt.MapFrom(order => order.Price))
            .ForMember(orderLookupDto => orderLookupDto.Courier,
                opt =>
                    opt.MapFrom(order => order.Courier))
            .ForMember(orderLookupDto => orderLookupDto.Customer,
                opt =>
                    opt.MapFrom(order => order.Customer))
            .ForMember(orderLookupDto => orderLookupDto.SelectedProducts,
                opt =>
                    opt.MapFrom(order => order.SelectedProducts));
    }
}