using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Infrastructure;
using VShop.ProductApi.DTOs;
using VShop.ProductApi.Services;

namespace VShop.ProductApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
  private readonly IProductService _productService;

  public ProductsController(IProductService productService)
  {
    _productService = productService;
  }

  [HttpGet]
  public async Task<ActionResult<IEnumerable<ProductDTO>>> Get()
  {
    var productsDto = await _productService.GetProducts();
    if (productsDto == null)
    {
      return NotFound("Product not found");
    }
    return Ok(productsDto);
  }

  [HttpGet("{id}", Name = "GetProduct")]
  public async Task<ActionResult<ProductDTO>> Get(int id)
  {
    var productsDto = await _productService.GetProductById(id);
    if (productsDto == null)
    {
      return NotFound("Product not found");
    }
    return Ok(productsDto);
  }

  [HttpPost]
  public async Task<ActionResult> Post([FromBody] ProductDTO productDTO)
  {
    if(productDTO == null)
    {
      return BadRequest();
    }

    await _productService.AddProduct(productDTO);

    return new CreatedAtRouteResult("GetProduct", new { id = productDTO.ProductId }, productDTO);
  }

  [HttpDelete("{id}")]
  public async Task<ActionResult<ProductDTO>> Delete(int id)
  {
    var productDto = await _productService.GetProductById(id);

    if(productDto == null)
    {
      return NotFound("Product not found");
    }

    await _productService.RemoveProduct(id);

    return Ok(productDto);
  }

}
