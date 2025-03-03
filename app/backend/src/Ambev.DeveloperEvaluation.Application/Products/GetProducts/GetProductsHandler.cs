using MediatR;
using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProducts;

/// <summary>
/// Handler for processing GetProductsQuery requests
/// </summary>
public class GetProductsHandler : IRequestHandler<GetProductsQuery, List<ProductResult>>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductsHandler
    /// </summary>
    /// <param name="repository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetProductsHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductsCommand request
    /// </summary>
    /// <returns>The list of all products and its details</returns>
    public async Task<List<ProductResult>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
    {
        var response = await _repository.GetAllAsync(cancellationToken);
        var result = _mapper.Map<List<ProductResult>>(response);
        return result;
    }
}
