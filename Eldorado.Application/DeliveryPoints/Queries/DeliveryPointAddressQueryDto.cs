using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.DeliveryPoints.Queries;

public class DeliveryPointAddressQueryDto : IMapWith<DeliveryPointAddress>
{
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeliveryPointAddress, DeliveryPointAddressQueryDto>()
            .ForMember(deliveryPointAddressQueryDto => deliveryPointAddressQueryDto.City,
                opt =>
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.City))
            .ForMember(deliveryPointAddressQueryDto => deliveryPointAddressQueryDto.Street,
                opt =>
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.Street))
            .ForMember(deliveryPointAddressQueryDto => deliveryPointAddressQueryDto.House,
                opt =>
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.House));
    }
    
}