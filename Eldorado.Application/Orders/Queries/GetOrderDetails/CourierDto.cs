using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eldorado.Application.Orders.Queries.GetOrderDetails
{
    public class CourierDto : IMapWith<Courier>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Courier, CourierDto>()
                .ForMember(courierDto => courierDto.Id,
                opt => 
                    opt.MapFrom(courier => courier.Id))
                .ForMember(courierDto => courierDto.FirstName,
                opt => 
                    opt.MapFrom(courier => courier.FirstName))
                .ForMember(courierDto => courierDto.LastName,
                opt => 
                    opt.MapFrom(courier => courier.LastName))
                .ForMember(courierDto => courierDto.Phone,
                opt => 
                    opt.MapFrom(courier => courier.Phone));
        }
    }
}
