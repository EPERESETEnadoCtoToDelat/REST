using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Couriers.Commands.CreateCourier;

namespace Eldorado.WebApi.Models.Courier
{
    public class CreateCourierDto : IMapWith<CreateCourierCommand>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public long PassportNumber { get; set; }
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCourierDto, CreateCourierCommand>()
                .ForMember(createCourierCommand => createCourierCommand.FirstName,
                opt => opt.MapFrom(createCourierDto => createCourierDto.FirstName))
                .ForMember(createCourierCommand => createCourierCommand.LastName,
                opt => opt.MapFrom(createCourierDto => createCourierDto.LastName))
                .ForMember(createCourierCommand => createCourierCommand.Phone,
                opt => opt.MapFrom(createCourierDto => createCourierDto.Phone))
                .ForMember(createCourierCommand => createCourierCommand.PassportNumber,
                opt => opt.MapFrom(createCourierDto => createCourierDto.PassportNumber))
                .ForMember(createCourierCommand => createCourierCommand.Age,
                opt => opt.MapFrom(createCourierDto => createCourierDto.Age));
        }
    }
}
