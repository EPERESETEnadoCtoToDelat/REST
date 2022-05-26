using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Orders.Queries.GetOrderDetails
{
    public class OrderDetailsVm : IMapWith<Order>
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public int Price { get; set; }
        public List<SelectedProductQueryDto> SelectedProducts { get; set; } = null!;
        public CourierDto? Courier { get; set; }
        //public DeliveryPointQueryDto? DeliveryPoint { get; set; }
        public CustomerDto? Customer { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Order, OrderDetailsVm>()
                .ForMember(orderDetailsVm => orderDetailsVm.Id,
                    opt => 
                        opt.MapFrom(order => order.Id))
                .ForMember(orderDetailsVm => orderDetailsVm.Date,
                    opt => 
                        opt.MapFrom(order => order.Date))
                .ForMember(orderDetailsVm => orderDetailsVm.Price,
                    opt => 
                        opt.MapFrom(order => order.Price))
                .ForMember(orderDetailsVm => orderDetailsVm.Courier,
                    opt =>
                        opt.MapFrom(order => order.Courier))
                .ForMember(orderDetailsVm => orderDetailsVm.Customer,
                    opt =>
                        opt.MapFrom(order => order.Customer))
                .ForMember(orderDetailsVm => orderDetailsVm.SelectedProducts,
                    opt =>
                        opt.MapFrom(order => order.SelectedProducts))
                /*.ForMember(orderDetailsVm => orderDetailsVm.DeliveryPoint,
                    opt =>
                        opt.MapFrom(order => order.DeliveryPoint))*/
          
                /*.ForMember(orderDetailsVm => orderDetailsVm.DeliveryPoint,
                    opt =>
                        opt.MapFrom(order => order.DeliveryPoint))
                .ForMember(orderDetailsVm => orderDetailsVm.Customer,
                    opt =>
                        opt.MapFrom(order => order.Customer))
                .ForMember(orderDetailsVm => orderDetailsVm.SelectedProducts,
                    opt =>
                        opt.MapFrom(order => order.SelectedProducts))*/;
        }
    }
}
