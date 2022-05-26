using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Customers.Commands.UpdateCustomer;

namespace Eldorado.WebApi.Models
{
    public class UpdateCustomerDto : IMapWith<UpdateCustomerCommand>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Age { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateCustomerDto, UpdateCustomerCommand>()
                .ForMember(customerCommand => customerCommand.Id,
                    opt => opt.MapFrom(customerDto => customerDto.Id))
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
