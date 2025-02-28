namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public record CreateProductRequest(
    string Title,
    decimal Price,
    string Description,
    string Category,
    string Image
);