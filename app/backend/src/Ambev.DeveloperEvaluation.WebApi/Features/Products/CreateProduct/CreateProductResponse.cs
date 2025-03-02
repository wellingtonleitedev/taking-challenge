namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;

public record CreateProductResponse(
    string Title,
    decimal Price,
    string Description,
    string Category,
    string Image
);