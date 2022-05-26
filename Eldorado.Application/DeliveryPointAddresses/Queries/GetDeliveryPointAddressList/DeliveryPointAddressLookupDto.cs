using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressList;

public class DeliveryPointAddressLookupDto : IMapWith<DeliveryPointAddress>
{
    public Guid Id { get; set; }
    public string? City { get; set; }
    public string? Street { get; set; }
    public int? House { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<DeliveryPointAddress, DeliveryPointAddressLookupDto>()
            .ForMember(deliveryPointAddressLookupDto => deliveryPointAddressLookupDto.Id,
                opt =>
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.Id))
            .ForMember(deliveryPointAddressLookupDto => deliveryPointAddressLookupDto.City,
                opt =>
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.City))
            .ForMember(deliveryPointAddressLookupDto => deliveryPointAddressLookupDto.Street,
                opt =>
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.Street))
            .ForMember(deliveryPointAddressLookupDto => deliveryPointAddressLookupDto.House,
                opt =>
                    opt.MapFrom(deliveryPointAddress => deliveryPointAddress.House));
    }
}