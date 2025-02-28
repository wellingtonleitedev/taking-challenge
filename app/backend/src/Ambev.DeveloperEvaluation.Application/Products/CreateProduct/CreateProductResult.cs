namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <remarks>
/// This response contains the unique identifier of the newly created product,
/// which can be used for subsequent operations or reference.
/// </remarks>
public record CreateProductResult(
    Guid Id, 
    string Title, 
    decimal Price, 
    string Description, 
    string Category, 
    string Image
);
