using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.DeliveryPoints.Commands.CreateDeliveryPoint;

namespace Eldorado.WebApi.Models.DeliveryPoint;

public class CreateDeliveryPointDto : IMapWith<CreateDeliveryPointCommand>
{
    public DateTime WorkingTime { get; set; }
    public DeliveryPointAddressDto? DeliveryPointAddress { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDeliveryPointDto, CreateDeliveryPointCommand>()
            .ForMember(createDeliveryPointCommand => createDeliveryPointCommand.WorkingTime,
                opt =>
                    opt.MapFrom(createDeliveryPointDto => createDeliveryPointDto.WorkingTime))
            .ForMember(createDeliveryPointCommand => createDeliveryPointCommand.DeliveryPointAddress,
                opt =>
                    opt.MapFrom(createDeliveryPointDto => createDeliveryPointDto.DeliveryPointAddress));
    }
}