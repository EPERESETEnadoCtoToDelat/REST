using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.DeliveryPoints.Queries.GetDeliveryPointDetails;

public class DeliveryPointDetailsVm : IMapWith<DeliveryPoint>
{
    public Guid Id { get; set; }
    public DateTime WorkingTime { get; set; }
    public DeliveryPointAddressQueryDto DeliveryPointAddress { get; set; } = null!;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeliveryPoint, DeliveryPointDetailsVm>()
            .ForMember(deliveryPointDetailsVm => deliveryPointDetailsVm.Id,
                opt =>
                    opt.MapFrom(deliveryPoint => deliveryPoint.Id))
            .ForMember(deliveryPointDetailsVm => deliveryPointDetailsVm.WorkingTime,
                opt =>
                    opt.MapFrom(deliveryPoint => deliveryPoint.WorkingTime))
            .ForMember(deliveryPointDetailsVm => deliveryPointDetailsVm.DeliveryPointAddress,
                opt =>
                    opt.MapFrom(deliveryPoint => deliveryPoint.DeliveryPointAddress));
    }
}