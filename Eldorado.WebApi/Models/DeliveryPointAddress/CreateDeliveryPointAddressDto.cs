using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.DeliveryPointAddresses.Commands.CreateDeliveryPointAddress;
using Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressList;

namespace Eldorado.WebApi.Models.DeliveryPointAddress;

public class CreateDeliveryPointAddressDto : IMapWith<CreateDeliveryPointAddressesCommand>
{
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<CreateDeliveryPointAddressDto, CreateDeliveryPointAddressesCommand>()
            .ForMember(createDeliveryPointAddressesCommand => createDeliveryPointAddressesCommand.City,
                opt =>
                    opt.MapFrom(createDeliveryPointAddressDto => createDeliveryPointAddressDto.City))
            .ForMember(createDeliveryPointAddressesCommand => createDeliveryPointAddressesCommand.Street,
                opt =>
                    opt.MapFrom(createDeliveryPointAddressDto => createDeliveryPointAddressDto.Street))
            .ForMember(createDeliveryPointAddressesCommand => createDeliveryPointAddressesCommand.House,
                opt =>
                    opt.MapFrom(createDeliveryPointAddressDto => createDeliveryPointAddressDto.House));
    }
}