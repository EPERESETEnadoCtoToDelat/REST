using AutoMapper;
using Eldorado.Application.Common.Mappings;
using Eldorado.Application.ProductCatigories.Commands.CreateProductCategory;
using Eldorado.Application.ProductCatigories.Commands.DeleteProductCategory;
using Eldorado.Application.ProductCatigories.Commands.UpdateProductCategory;
using Eldorado.Application.ProductCatigories.Queries.GetProductCategoryDetails;
using Eldorado.Application.ProductCatigories.Queries.GetProductCategoryList;
using Eldorado.WebApi.Models.ProductCategory;
using Microsoft.AspNetCore.Mvc;

namespace Eldorado.WebApi.Controllers;

[Route("api/[controller]")]
public class ProductCategoryController : BaseController
{
    private readonly IMapper _mapper;

    public ProductCategoryController(IMapper mapper) =>
        _mapper = mapper;

    [HttpGet("id")]
    public async Task<ActionResult<ProductCategoryDetailsVm>> Get(Guid id)
    {
        var query = new GetProductCategoryDetailsQuery { Id = id };
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpGet]
    public async Task<ActionResult<ProductCategoryListVm>> GetAll()
    {
        var query = new GetProductCategoryListQuery();
        var vm = await Mediator.Send(query);
        return Ok(vm);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateProductCategoryDto createProductCategoryDto)
    {
        var command = _mapper.Map<CreateProductCategoryCommand>(createProductCategoryDto);
        var productCategoryId = await Mediator.Send(command);
        return Ok(productCategoryId);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateProductCategoryDto updateProductCategoryDto)
    {
        var command = _mapper.Map<UpdateProductCategoryCommand>(updateProductCategoryDto);
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var command = new DeleteProductCategoryCommand { Id = id };
        await Mediator.Send(command);
        return NoContent();
    }
}