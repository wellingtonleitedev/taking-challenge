using MediatR;
using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

public record GetProductQuery(Guid Id): IRequest<ProductResult>{}