namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;

public record ProductResponse(
    Guid Id,
    string Title,
    decimal Price,
    string Description,
    string Category,
    string Image
);