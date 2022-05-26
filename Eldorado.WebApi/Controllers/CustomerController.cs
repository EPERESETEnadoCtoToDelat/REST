using AutoMapper;
using Eldorado.Application.Customers.Commands.CreateCustomer;
using Eldorado.Application.Customers.Commands.UpdateCustomer;
using Eldorado.Application.Customers.Commands.DeleteCustomer;
using Eldorado.Application.Customers.Queries.GetCustomerDetails;
using Eldorado.Application.Customers.Queries.GetCustomerList;
using Eldorado.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace Eldorado.WebApi.Controllers
{

    [Route("api/[controller]")]
    public class CustomerController : BaseController
    {
        private readonly IMapper _mapper;

        public CustomerController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CustomerListVm>> GetAll()
        {
            var query = new GetCustomerListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CustomerDetailsVm>> Get(Guid id)
        {
            var query = new GetCustomerDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCustomerDto createCustomerDto)
        {
            var command = _mapper.Map<CreateCustomerCommand>(createCustomerDto);
            var customerId = await Mediator.Send(command);

            return Ok(customerId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCustomerDto updateCustomerDto)
        {
            var command = _mapper.Map<UpdateCustomerCommand>(updateCustomerDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCustomerCommand { Id = id };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
