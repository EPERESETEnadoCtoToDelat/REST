using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;

namespace Eldorado.Application.Orders.Queries.GetOrderList;

public class CourierForOrderLookupDto : IMapWith<Courier>
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Phone { get; set; } = string.Empty;

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Courier, CourierForOrderLookupDto>()
            .ForMember(courierLookupDto => courierLookupDto.Id,
                opt =>
                    opt.MapFrom(courier => courier.Id))
            .ForMember(courierLookupDto => courierLookupDto.FirstName,
                opt =>
                    opt.MapFrom(courier => courier.FirstName))
            .ForMember(courierLookupDto => courierLookupDto.LastName,
                opt =>
                    opt.MapFrom(courier => courier.LastName))
            .ForMember(courierLookupDto => courierLookupDto.Phone,
                opt =>
                    opt.MapFrom(courier => courier.Phone));
    }
}