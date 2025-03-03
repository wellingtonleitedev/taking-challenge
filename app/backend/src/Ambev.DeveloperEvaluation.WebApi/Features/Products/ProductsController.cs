using MediatR;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Ambev.DeveloperEvaluation.WebApi.Common;
using Ambev.DeveloperEvaluation.Application.Products.GetProducts;
using Ambev.DeveloperEvaluation.Application.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.CreateProduct;
using Ambev.DeveloperEvaluation.WebApi.Features.Products.Common;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Products;

/// <summary>
/// Controller for managing product operations
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ProductsController : BaseController
{
    private readonly IMapper _mapper;
    private readonly ISender _mediator;

    /// <summary>
    /// Initializes a new instance of ProductsController
    /// </summary>
    /// <param name="mediator">The mediator instance</param>
    public ProductsController(IMapper mapper, ISender mediator)
    {
        _mapper = mapper;
        _mediator = mediator;
    }

    /// <summary>
    /// Retrieves all products
    /// </summary>
    /// <param name="cancellationToken">Cancellation token</param>
    /// <returns>The list of all products</returns>
    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        var response = await _mediator.Send(new GetProductsQuery(), cancellationToken);

        return Ok(new ApiResponseWithData<List<ProductResponse>>
        {
            Success = true,
            Message = "Products retrieved successfully",
            Data = _mapper.Map<List<ProductResponse>>(response)
        });
    }

    /// <summary>
    /// Create a new product
    /// </summary>
    /// <param name="request">The product creation request</param>
    /// <returns>The created product detail</returns>
    [HttpPost]
    public async Task<IActionResult> Post(CreateProductRequest request)
    {
        var command = _mapper.Map<CreateProductCommand>(request);
        var response = await _mediator.Send(command);

        return Created(string.Empty, new ApiResponseWithData<CreateProductResponse>
        {
            Success = true,
            Message = "Product created successfully",
            Data = _mapper.Map<CreateProductResponse>(response)
        });
    }
}