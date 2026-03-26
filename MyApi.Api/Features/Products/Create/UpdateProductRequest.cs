using System.ComponentModel.DataAnnotations;

namespace MyApi.Api.Features.Products.Update;

public class UpdateProductRequest
{
    [Required]
    [StringLength(100)]
    public string Name { get; set; } = string.Empty;

    [Range(0.01, 999999)]
    public decimal Price { get; set; }
}