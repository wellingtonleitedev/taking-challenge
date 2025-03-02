namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Represents the response returned after successfully creating a new product.
/// </summary>
/// <remarks>
/// This response contains the details of the newly created product.
/// </remarks>
public class CreateProductResult
{
    /// <summary>
    /// The unique identifier of the created product
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// The product's name
    /// </summary>
    public string Title { get; set; } = string.Empty;
    
    /// <summary>
    /// The product's price
    /// </summary>
    public decimal Price { get; set; }
    
    /// <summary>
    /// The product's description
    /// </summary>
    public string Description { get; set; } = string.Empty;
    
    /// <summary>
    /// The product's category
    /// </summary>
    public string Category { get; set; } = string.Empty;
    
    /// <summary>
    /// The product's image
    /// </summary>
    public string Image { get; set; } = string.Empty;
}
