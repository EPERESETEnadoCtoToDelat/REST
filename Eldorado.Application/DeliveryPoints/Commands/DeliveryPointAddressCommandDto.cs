using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.DeliveryPoints.Commands;

public class DeliveryPointAddressCommandDto : IMapWith<DeliveryPointAddress>
{
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeliveryPointAddressCommandDto, DeliveryPointAddress>()
            .ForMember(deliveryPointAddress => deliveryPointAddress.City,
                opt =>
                    opt.MapFrom(deliveryPointAddressDto => deliveryPointAddressDto.City))
            .ForMember(deliveryPointAddress => deliveryPointAddress.Street,
                opt =>
                    opt.MapFrom(deliveryPointAddressDto => deliveryPointAddressDto.Street))
            .ForMember(deliveryPointAddress => deliveryPointAddress.House,
                opt =>
                    opt.MapFrom(deliveryPointAddressDto => deliveryPointAddressDto.House));
    }
}