using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Queries.GetCourierList
{
    public class CourierLookupDto : IMapWith<Courier>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public long PassportNumber { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Courier, CourierLookupDto>()
                .ForMember(courierLookupDto => courierLookupDto.Id,
                opt => opt.MapFrom(courier => courier.Id))
                .ForMember(courierLookupDto => courierLookupDto.FirstName,
                opt => opt.MapFrom(courier => courier.FirstName))
                .ForMember(courierLookupDto => courierLookupDto.LastName,
                opt => opt.MapFrom(courier => courier.LastName))
                .ForMember(courierLookupDto => courierLookupDto.Phone,
                opt => opt.MapFrom(courier => courier.Phone))
                .ForMember(courierLookupDto => courierLookupDto.PassportNumber,
                opt => opt.MapFrom(courier => courier.PassportNumber))
                .ForMember(courierLookupDto => courierLookupDto.Age,
                opt => opt.MapFrom(courier => courier.Age));
        }
    }
}
