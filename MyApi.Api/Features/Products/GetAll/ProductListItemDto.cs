namespace MyApi.Api.Features.Products.GetAll;

public class ProductListItemDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public decimal Price { get; set; }
}