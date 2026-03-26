using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApi.Api.Features.Products.Create;
using MyApi.Api.Features.Products.GetAll;
using MyApi.Api.Features.Products.GetById;
using MyApi.Api.Features.Products.Update;
using MyApi.Application.Abstractions;
using MyApi.Domain.Entities;

namespace MyApi.Api.Controllers;

// handles HTTP and delegates to the repository boundary
// uses the attribute in ASP.NET Core for basic security
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    // the boundary
    private readonly IProductRepository _products;

    public ProductsController(IProductRepository products)
    {
        _products = products;
    }

    [Authorize]
    [HttpGet]
    public async Task<ActionResult<List<ProductListItemDto>>> GetAll(CancellationToken cancellationToken)
    {
        var items = await _products.GetAllAsync(cancellationToken);

        var response = items.Select(x => new ProductListItemDto
        {
            Id = x.Id,
            Name = x.Name,
            Price = x.Price
        }).ToList();

        return Ok(response);
    }

    [Authorize]
    [HttpGet("{id:int}")]
    public async Task<ActionResult<ProductDto>> GetById(int id, CancellationToken cancellationToken)
    {
        var product = await _products.GetByIdAsync(id, cancellationToken);

        if (product is null)
            return NotFound();

        return Ok(new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price,
            CreatedUtc = product.CreatedUtc
        });
    }

    [Authorize]
    [HttpPost]
    public async Task<ActionResult<ProductDto>> Create(
        [FromBody] CreateProductRequest request,
        CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Name = request.Name,
            Price = request.Price
        };

        var created = await _products.AddAsync(product, cancellationToken);

        var response = new ProductDto
        {
            Id = created.Id,
            Name = created.Name,
            Price = created.Price,
            CreatedUtc = created.CreatedUtc
        };

        return CreatedAtAction(nameof(GetById), new { id = created.Id }, response);
    }

    [Authorize]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(
        int id,
        [FromBody] UpdateProductRequest request,
        CancellationToken cancellationToken)
    {
        var product = new Product
        {
            Id = id,
            Name = request.Name,
            Price = request.Price
        };

        var updated = await _products.UpdateAsync(product, cancellationToken);

        if (!updated)
            return NotFound();

        return NoContent();
    }

    [Authorize(Roles = "Admin")]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id, CancellationToken cancellationToken)
    {
        var deleted = await _products.DeleteAsync(id, cancellationToken);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}