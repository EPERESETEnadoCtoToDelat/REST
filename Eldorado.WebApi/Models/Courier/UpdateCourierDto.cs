using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Couriers.Commands.UpdateCourier;

namespace Eldorado.WebApi.Models.Courier
{
    public class UpdateCourierDto : IMapWith<UpdateCourierCommand>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public long PassportNumber { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCourierDto, UpdateCourierCommand>()
                .ForMember(updateCourierCommand => updateCourierCommand.Id,
                opt => opt.MapFrom(updateCourierDto => updateCourierDto.Id))
                .ForMember(updateCourierCommand => updateCourierCommand.FirstName,
                opt => opt.MapFrom(updateCourierDto => updateCourierDto.FirstName))
                .ForMember(updateCourierCommand => updateCourierCommand.LastName,
                opt => opt.MapFrom(updateCourierDto => updateCourierDto.LastName))
                .ForMember(updateCourierCommand => updateCourierCommand.Phone,
                opt => opt.MapFrom(updateCourierDto => updateCourierDto.Phone))
                .ForMember(updateCourierCommand => updateCourierCommand.PassportNumber,
                opt => opt.MapFrom(updateCourierDto => updateCourierDto.PassportNumber))
                .ForMember(updateCourierCommand => updateCourierCommand.Age,
                opt => opt.MapFrom(updateCourierDto => updateCourierDto.Age));
        }
    }
}
