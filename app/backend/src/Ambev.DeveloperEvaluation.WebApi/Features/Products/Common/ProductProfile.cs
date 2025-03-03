using AutoMapper;
using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;

/// <summary>
/// Profile for mapping between Application and API product responses
/// </summary>
public class ProductProfile : Profile
{
  /// <summary>
  /// Initializes the mappings for product feature
  /// </summary>
  public ProductProfile()
  {
    CreateMap<ProductResult, ProductResponse>();
  }
}
