using AutoMapper;
using Eldorado.Application.Common.Excel;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.Orders.Commands.CreateOrder;
using Eldorado.Application.Orders.Commands.DeleteOrder;
using Eldorado.Application.Orders.Queries.GetOrderDetails;
using Eldorado.Application.Orders.Queries.GetOrderList;
using Eldorado.Domain;
using Eldorado.WebApi.Models.Order;
using Microsoft.AspNetCore.Mvc;

namespace Eldorado.WebApi.Controllers;

[Route("api/[controller]")]
public class OrderController : BaseController
{
   private readonly IMapper _mapper;
   private readonly ExportToExcel _export;

   public OrderController(IMapper mapper, ExportToExcel export) =>
      (_mapper, _export) = (mapper, export);

   [HttpGet("{orderId}/{customerId}")]
   public async Task<ActionResult<OrderDetailsVm>> Get(Guid orderId, Guid customerId)
   {
      var query = new GetOrderDetailsQuery { Id = orderId, CustomerId = customerId };
      var vm = await Mediator.Send(query);
      return Ok(vm);
   }
   
   [HttpGet("download/{orderId}/{customerId}")]
   public async Task<IActionResult> DownloadOrderToExcel(Guid orderId, Guid customerId)
   {
      var query = new GetOrderDetailsQuery { Id = orderId, CustomerId = customerId };
      var vm = await Mediator.Send(query);
      var content = _export.OrderExportToExcel(vm);
      return File(
         content,
         "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
         $"Order-{DateTime.Now.ToString("yyyy/MM/dd/HH/mm/ss/fff")}.xlsx"); //поменять дату
   }

   [HttpGet("downloadAll")]
   public async Task<IActionResult> DownloadOrdersToExcel()
   {
      var query = new GetOrderListQuery();
      var vm = await Mediator.Send(query);
      var content = _export.OrdersExportToExcel(vm.Orders!);
      return File(
         content,
         "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
         $"Order-{DateTime.Now.ToString("yyyy/MM/dd/HH/mm/ss/fff")}.xlsx");
   }

   [HttpGet]
   public async Task<ActionResult<OrderListVm>> GetAll()
   {
      var query = new GetOrderListQuery();
      var vm = await Mediator.Send(query);
      return Ok(vm);
   }
   
   [HttpPost]
   public async Task<ActionResult<Guid>> Create([FromBody] CreateOrderDto createOrderDto)
   {
      var command = _mapper.Map<CreateOrderCommand>(createOrderDto);
      var orderId = await Mediator.Send(command);
      return Ok(orderId);
   }

   [HttpDelete("{customerId}/{orderId}")]
   public async Task<IActionResult> Delete(Guid customerId, Guid orderId)
   {
      var command = new DeleteOrderCommand { Id = orderId, CustomerId = customerId };
      await Mediator.Send(command);
      return NoContent();
   }
}