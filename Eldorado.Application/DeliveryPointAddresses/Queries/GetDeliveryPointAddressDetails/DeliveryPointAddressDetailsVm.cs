using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressDetails;

public class DeliveryPointAddressDetailsVm : IMapWith<DeliveryPointAddress>
{
    public Guid Id { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeliveryPointAddress, DeliveryPointAddressDetailsVm>()
            .ForMember(deliveryPointAddressDetailsDto => deliveryPointAddressDetailsDto.Id,
                opt => opt
                    .MapFrom(deliveryPointAddress => deliveryPointAddress.Id))
            .ForMember(deliveryPointAddressDetailsDto => deliveryPointAddressDetailsDto.City,
                opt => opt
                    .MapFrom(deliveryPointAddress => deliveryPointAddress.City))
            .ForMember(deliveryPointAddressDetailsDto => deliveryPointAddressDetailsDto.Street,
                opt => opt
                    .MapFrom(deliveryPointAddress => deliveryPointAddress.Street))
            .ForMember(deliveryPointAddressDetailsDto => deliveryPointAddressDetailsDto.House,
                opt => opt
                    .MapFrom(deliveryPointAddress => deliveryPointAddress.House));
    }
}