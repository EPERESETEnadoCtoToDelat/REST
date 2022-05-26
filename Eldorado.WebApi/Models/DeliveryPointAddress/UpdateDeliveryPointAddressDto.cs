using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.DeliveryPointAddresses.Commands.UpdateDeliveryPointAddress;

namespace Eldorado.WebApi.Models.DeliveryPointAddress;

public class UpdateDeliveryPointAddressDto : IMapWith<UpdateDeliveryPointAddressCommand>
{
    public Guid Id { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<UpdateDeliveryPointAddressDto, UpdateDeliveryPointAddressCommand>()
            .ForMember(updateDeliveryPointAddressesCommand => updateDeliveryPointAddressesCommand.Id,
                opt => 
                    opt.MapFrom(updateDeliveryPointAddressDto => updateDeliveryPointAddressDto.Id))
            .ForMember(updateDeliveryPointAddressesCommand => updateDeliveryPointAddressesCommand.City,
                opt =>
                    opt.MapFrom(updateDeliveryPointAddressDto => updateDeliveryPointAddressDto.City))
            .ForMember(updateDeliveryPointAddressesCommand => updateDeliveryPointAddressesCommand.Street,
                opt =>
                    opt.MapFrom(updateDeliveryPointAddressDto => updateDeliveryPointAddressDto.Street))
            .ForMember(updateDeliveryPointAddressesCommand => updateDeliveryPointAddressesCommand.House,
                opt =>
                    opt.MapFrom(updateDeliveryPointAddressDto => updateDeliveryPointAddressDto.House));
    }
}