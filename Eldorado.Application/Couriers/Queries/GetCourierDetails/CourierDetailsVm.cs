using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Couriers.Queries.GetCourierDetails
{
    public class CourierDetailsVm : IMapWith<Courier>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public long PassportNumber { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Courier, CourierDetailsVm>()
                .ForMember(courierDetaisVm => courierDetaisVm.Id,
                opt => opt.MapFrom(courier => courier.Id))
                .ForMember(courierDetaisVm => courierDetaisVm.FirstName,
                opt => opt.MapFrom(courier => courier.FirstName))
                .ForMember(courierDetaisVm => courierDetaisVm.LastName,
                opt => opt.MapFrom(courier => courier.LastName))
                .ForMember(courierDetaisVm => courierDetaisVm.Phone,
                opt => opt.MapFrom(courier => courier.Phone))
                .ForMember(courierDetaisVm => courierDetaisVm.PassportNumber,
                opt => opt.MapFrom(courier => courier.PassportNumber))
                .ForMember(courierDetaisVm => courierDetaisVm.Age,
                opt => opt.MapFrom(courier => courier.Age));
        }
    }
}
