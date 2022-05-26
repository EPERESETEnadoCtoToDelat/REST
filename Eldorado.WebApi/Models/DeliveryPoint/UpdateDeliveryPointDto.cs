using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.DeliveryPoints.Commands.UpdateDeliveryPoint;

namespace Eldorado.WebApi.Models.DeliveryPoint;

public class UpdateDeliveryPointDto : IMapWith<UpdateDeliveryPointCommand>
{
    public Guid Id { get; set; }
    public DateTime WorkingTime { get; set; }
    public DeliveryPointAddressDto? DeliveryPointAddress { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDeliveryPointDto, UpdateDeliveryPointCommand>()
            .ForMember(updateDeliveryPointCommand => updateDeliveryPointCommand.Id,
                opt =>
                    opt.MapFrom(updateDeliveryPointDto => updateDeliveryPointDto.Id))
            .ForMember(updateDeliveryPointCommand => updateDeliveryPointCommand.WorkingTime,
                opt =>
                    opt.MapFrom(updateDeliveryPointDto => updateDeliveryPointDto.WorkingTime))
            .ForMember(updateDeliveryPointCommand => updateDeliveryPointCommand.DeliveryPointAddressCommand,
                opt =>
                    opt.MapFrom(updateDeliveryPointDto => updateDeliveryPointDto.DeliveryPointAddress));
    }
}