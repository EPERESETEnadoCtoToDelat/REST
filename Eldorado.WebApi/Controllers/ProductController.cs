using AutoMapper;
using Eldorado.Application.Products.Commands.CreateProduct;
using Eldorado.Application.Products.Commands.DeleteProduct;
using Eldorado.Application.Products.Commands.UpdateProduct;
using Eldorado.Application.Products.Queries.GetProductDetails;
using Eldorado.Application.Products.Queries.GetProductList;
using Eldorado.WebApi.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Eldorado.WebApi.Controllers;

[Route("api/[controller]")]
public class ProductController : BaseController
{
    private readonly IMapper _mapper;

    public ProductController(IMapper mapper) =>
        _mapper = mapper;

    [HttpGet("{id}")]
    public async Task<ActionResult<ProductDetailsVm>> Get(Guid id)
    {
        var query = new GetProductDetailsQuery { Id = id };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet]
    public async Task<ActionResult<ProductListVm>> GetAll()
    {
        var query = new GetProductListQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProductDto createProductDto)
    {
        var command = _mapper.Map<CreateProductCommand>(createProductDto);
        var productId = await Mediator.Send(command);
        return Ok(productId);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductDto updateProductDto)
    {
        var command = _mapper.Map<UpdateProductCommand>(updateProductDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteProductCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}