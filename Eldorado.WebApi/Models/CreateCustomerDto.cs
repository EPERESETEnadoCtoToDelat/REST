using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Customers.Commands.CreateCustomer;

namespace Eldorado.WebApi.Models
{
    public class CreateCustomerDto : IMapWith<CreateCustomerCommand>
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public int Age { get; set; }
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateCustomerDto, CreateCustomerCommand>()
                .ForMember(customerCommand => customerCommand.FirstName,
                    opt => opt.MapFrom(customerDto => customerDto.FirstName))
                .ForMember(customerCommand => customerCommand.LastName,
                    opt => opt.MapFrom(customerDto => customerDto.LastName))
                .ForMember(customerCommand => customerCommand.Age,
                    opt => opt.MapFrom(customerDto => customerDto.Age))
                .ForMember(customerCommand => customerCommand.Phone,
                    opt => opt.MapFrom(customerDto => customerDto.Phone))
                .ForMember(customerCommand => customerCommand.Email,
                    opt => opt.MapFrom(customerDto => customerDto.Email));
        }
    }
}
