using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.DeliveryPoints.Queries.GetDeliveryPointList;

public class DeliveryPointLookupDto : IMapWith<DeliveryPoint>
{
    public Guid Id { get; set; }
    public DateTime WorkingTime { get; set; }
    public DeliveryPointAddressQueryDto DeliveryPointAddress { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeliveryPoint, DeliveryPointLookupDto>()
            .ForMember(deliveryPointLookupDto => deliveryPointLookupDto.Id,
                opt =>
                    opt.MapFrom(deliveryPoint => deliveryPoint.Id))
            .ForMember(deliveryPointLookupDto => deliveryPointLookupDto.WorkingTime,
                opt =>
                    opt.MapFrom(deliveryPoint => deliveryPoint.WorkingTime))
            .ForMember(deliveryPointLookupDto => deliveryPointLookupDto.DeliveryPointAddress,
                opt =>
                    opt.MapFrom(deliveryPoint => deliveryPoint.DeliveryPointAddress));
    }
}