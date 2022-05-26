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
    public class DeliveryPointQueryDto : IMapWith<DeliveryPoint>
    {
        public Guid Id { get; set; }
        public DeliveryPointAddressQueryDto DeliveryPointAddressQuery { get; set; } = null!;
        public DateTime WorkingTime { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeliveryPoint, DeliveryPointQueryDto>()
                .ForMember(deliveryPointDto => deliveryPointDto.Id,
                    opt =>
                        opt.MapFrom(deliveryPoint => deliveryPoint.Id))
                .ForMember(deliveryPointDto => deliveryPointDto.WorkingTime,
                    opt =>
                        opt.MapFrom(deliveryPoint => deliveryPoint.WorkingTime))
                .ForMember(deliveryPointDto => deliveryPointDto.DeliveryPointAddressQuery,
                    opt =>
                        opt.MapFrom(deliveryPoint => deliveryPoint.DeliveryPointAddress));
        }
    }
}
