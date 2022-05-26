using AutoMapper;
using Eldorado.Application.DeliveryPointAddresses.Commands.CreateDeliveryPointAddress;
using Eldorado.Application.DeliveryPointAddresses.Commands.DeleteDeliveryPointAddress;
using Eldorado.Application.DeliveryPointAddresses.Commands.UpdateDeliveryPointAddress;
using Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressDetails;
using Eldorado.Application.DeliveryPointAddresses.Queries.GetDeliveryPointAddressList;
using Eldorado.WebApi.Models.DeliveryPointAddress;
using Microsoft.AspNetCore.Mvc;

namespace Eldorado.WebApi.Controllers;

[Route("api/[controller]")]
public class DeliveryPointAddressController : BaseController
{
    private readonly IMapper _mapper;

    public DeliveryPointAddressController(IMapper mapper) =>
        _mapper = mapper;

    [HttpGet("{id}")]
    public async Task<ActionResult<DeliveryPointAddressDetailsVm>> Get(Guid id)
    {
        var query = new GetDeliveryPointAddressDetailsQuery { Id = id };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet]
    public async Task<ActionResult<DeliveryPointAddressListVm>> GetAll()
    {
        var query = new GetDeliveryPointAddressListQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDeliveryPointAddressDto createDeliveryPointAddressDto)
    {
        var command = _mapper.Map<CreateDeliveryPointAddressesCommand>(createDeliveryPointAddressDto);
        var deliveryPointAddressId = await Mediator.Send(command);
        return Ok(deliveryPointAddressId);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDeliveryPointAddressDto updateDeliveryPointAddressDto)
    {
        var command = _mapper.Map<UpdateDeliveryPointAddressCommand>(updateDeliveryPointAddressDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteDeliveryPointAddressCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}