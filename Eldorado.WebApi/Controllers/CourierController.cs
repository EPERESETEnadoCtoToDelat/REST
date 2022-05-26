using AutoMapper;
using Eldorado.Application.Couriers.Commands.CreateCourier;
using Eldorado.Application.Couriers.Commands.DeleteCourier;
using Eldorado.Application.Couriers.Commands.UpdateCourier;
using Eldorado.Application.Couriers.Queries.GetCourierDetails;
using Eldorado.Application.Couriers.Queries.GetCourierList;
using Eldorado.WebApi.Models.Courier;
using Microsoft.AspNetCore.Mvc;

namespace Eldorado.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class CourierController : BaseController
    {
        private readonly IMapper _mapper;

        public CourierController(IMapper mapper) =>
            _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<CourierListVm>> GetAll()
        {
            var query = new GetCourierListQuery();
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CourierDetailsVm>> Get(Guid id)
        {
            var query = new GetCourierDetailsQuery { Id = id };
            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateCourierDto createCourierDto)
        {
            var command = _mapper.Map<CreateCourierCommand>(createCourierDto);
            var courierId = await Mediator.Send(command);

            return Ok(courierId);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateCourierDto updateCourierDto)
        {
            var command = _mapper.Map<UpdateCourierCommand>(updateCourierDto);
            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteCourierCommand { Id = id };
            await Mediator.Send(command);

            return NoContent();
        }
    }
}
