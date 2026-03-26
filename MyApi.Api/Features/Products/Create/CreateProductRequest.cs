using System.ComponentModel.DataAnnotations;

namespace MyApi.Api.Features.Products.Create;

public class CreateProductRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 999999)]
    public decimal Price { get; set; }
}