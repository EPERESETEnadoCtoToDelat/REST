using AutoMapper;
using Eldorado.Application.Common.Mappings;

namespace Eldorado.WebApi.Models.DeliveryPoint;

public class DeliveryPointAddressDto : IMapWith<Application.DeliveryPoints.Commands.DeliveryPointAddressCommandDto>
{
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeliveryPointAddressDto, Application.DeliveryPoints.Commands.DeliveryPointAddressCommandDto>()
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