using AutoMapper;
using Eldorado.Application.CustomerAddresses.Commands.CreateCustomerAddress;
using Eldorado.Application.CustomerAddresses.Commands.DeleteCustomerAddress;
using Eldorado.Application.CustomerAddresses.Commands.UpdateCustomerAddress;
using Eldorado.Application.CustomerAddresses.Queries.GetCustomerAddressDetails;
using Eldorado.Application.CustomerAddresses.Queries.GetCustomerAddressList;
using Eldorado.WebApi.Models.CustomerAddress;
using Microsoft.AspNetCore.Mvc;

namespace Eldorado.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CustomerAddressController : BaseController
    {
        private readonly IMapper _mapper;

        public CustomerAddressController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CustomerAddressListVm>> GetAll()
        {
            var query = new GetCustomerAddressListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerAddressDetailsVm>> Get(Guid id)
        {
            var query = new GetCustomerAddressDetailsQuery { CustomerId = id };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCustomerAddressDto createCustomerAddressDto)
        {
            var command = _mapper.Map<CreateCustomerAddressCommand>(createCustomerAddressDto);
            var customerAddressId = await Mediator.Send(command);

            return Ok(customerAddressId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerAddressDto updateCustomerAddressDto)
        {
            var command = _mapper.Map<UpdateCustomerAddressCommand>(updateCustomerAddressDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}/{customerId}")] //заглушка customerId
        public async Task<IActionResult> Delete(Guid id, Guid customerId)
        {
            var command = new DeleteCustomerAddressCommand { Id = id, CustomerId = customerId };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
