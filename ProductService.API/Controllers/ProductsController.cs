using Microsoft.AspNetCore.Mvc;
using ProductService.Application.Contract;
using ProductService.Domain.Aggregates.ProductAggregate;
using ProductService.Domain.Aggregates.ProductAggregate.DTO.Request;
using ProductService.SharedKernel;
using System.Net.Mime;

namespace ProductService.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IProductService _productService;

    public ProductsController(IProductService productService)
    {
        _productService = productService;
    }

    [HttpGet("AllProducts")]
    [ProducesResponseType(typeof(ResponseWrapper<IEnumerable<Product>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<IEnumerable<Product>>> AllProducts()
    {
        var result = await _productService.GetAllProducts();

        if (!result.IsSuccessful)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpGet("Product/{id}")]
    [ProducesResponseType(typeof(ResponseWrapper<Product>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Product>> Product(string id)
    {
        var result = await _productService.GetProductById(id);

        if (!result.IsSuccessful)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }

    [HttpPost("AddNewProduct")]
    [ProducesResponseType(typeof(ResponseWrapper<string>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [Consumes(MediaTypeNames.Application.Json)]
    public async Task<ActionResult<Product>> AddNewProduct(AddNewProductRequest request)
    {
        var result = await _productService.AddNewProduct(request);

        if (!result.IsSuccessful)
        {
            return BadRequest(result.Message);
        }

        return Ok(result);
    }
}
