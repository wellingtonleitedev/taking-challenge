using MediatR;
using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Command for creating a new product.
/// </summary>
/// <remarks>
/// This query is used to get all products.
/// It implements <see cref="IRequest{TResponse}"/> to initiate the request 
/// that returns a <see cref="GetProductsResult"/>.
/// </remarks>
public record GetProductsQuery : IRequest<List<ProductResult>> {}