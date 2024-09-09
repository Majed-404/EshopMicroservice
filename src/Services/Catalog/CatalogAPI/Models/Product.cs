namespace CatalogAPI.Models;

public class Product
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!; //using this expression default! is to Avoiding Nullability Warnings from compiler
    public List<string> Category { get; set; } = new();
    public string Description { get; set; } = default!;
    public string ImageFile { get; set; } = default!;
    public decimal Price { get; set; }
}

