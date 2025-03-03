using MediatR;
using AutoMapper;
using FluentValidation;
using Ambev.DeveloperEvaluation.Domain.Repositories;
using Ambev.DeveloperEvaluation.Application.Products.Common;

namespace Ambev.DeveloperEvaluation.Application.Products.GetProduct;

/// <summary>
/// Handler for processing GetProductQuery requests
/// </summary>
public class GetProductHandler : IRequestHandler<GetProductQuery, ProductResult>
{
    private readonly IProductRepository _repository;
    private readonly IMapper _mapper;

    /// <summary>
    /// Initializes a new instance of GetProductHandler
    /// </summary>
    /// <param name="repository">The product repository</param>
    /// <param name="mapper">The AutoMapper instance</param>
    public GetProductHandler(IProductRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    /// <summary>
    /// Handles the GetProductQuery request
    /// </summary>
    /// <param name="command">The GetProduct command</param>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The product details</returns>
    public async Task<ProductResult> Handle(GetProductQuery command, CancellationToken cancellationToken)
    {
        var validator = new GetProductQueryValidator();
        var validationResult = await validator.ValidateAsync(command, cancellationToken);

        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        var product = await _repository.GetByIdAsync(command.Id, cancellationToken);

        if (product == null)
            throw new KeyNotFoundException($"Product with ID {command.Id} not found");

        return _mapper.Map<ProductResult>(product);
    }
}
