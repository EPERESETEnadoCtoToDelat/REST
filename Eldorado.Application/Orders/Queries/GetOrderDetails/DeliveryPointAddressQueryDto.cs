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
    public class DeliveryPointAddressQueryDto : IMapWith<DeliveryPointAddress>
    {
        public Guid Id { get; set; }
        public string? City { get; set; }
        public string? Street { get; set; }
        public int? House { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<DeliveryPointAddress, DeliveryPointAddressQueryDto>()
                .ForMember(deliveryPointAddressDto => deliveryPointAddressDto.Id, 
                opt => 
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.Id))
                .ForMember(deliveryPointAddressDto => deliveryPointAddressDto.City,
                opt => 
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.City))
                .ForMember(deliveryPointAddressDto => deliveryPointAddressDto.Street,
                opt => 
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.Street))
                .ForMember(deliveryPointAddressDto => deliveryPointAddressDto.House,
                opt => 
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.House));
        }
    }
}
