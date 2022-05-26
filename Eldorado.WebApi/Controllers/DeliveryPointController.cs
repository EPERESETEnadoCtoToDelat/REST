using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.DeliveryPoints.Commands.CreateDeliveryPoint;
using Eldorado.Application.DeliveryPoints.Commands.DeleteDeliveryPoint;
using Eldorado.Application.DeliveryPoints.Commands.UpdateDeliveryPoint;
using Eldorado.Application.DeliveryPoints.Queries.GetDeliveryPointDetails;
using Eldorado.Application.DeliveryPoints.Queries.GetDeliveryPointList;
using Eldorado.Application.Interfaces;
using Eldorado.Domain;
using Eldorado.WebApi.Models.DeliveryPoint;
using Microsoft.AspNetCore.Mvc;

namespace Eldorado.WebApi.Controllers;

[Route("api/[controller]")]
public class DeliveryPointController : BaseController
{
    private readonly IMapper _mapper;

    public DeliveryPointController(IMapper mapper) =>
        _mapper = mapper;

    [HttpGet]
    public async Task<ActionResult<DeliveryPointListVm>> GetAll()
    {
        var query = new GetDeliveryPointListQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DeliveryPointDetailsVm>> Get(Guid id)
    {
        var query = new GetDeliveryPointDetailsQuery { Id = id };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateDeliveryPointDto createDeliveryPointDto)
    {
        var command = _mapper.Map<CreateDeliveryPointCommand>(createDeliveryPointDto);
        var deliveryPointId = await Mediator.Send(command);
        return Ok(deliveryPointId);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateDeliveryPointDto updateDeliveryPointDto)
    {
        var command = _mapper.Map<UpdateDeliveryPointCommand>(updateDeliveryPointDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteDeliveryPointCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}