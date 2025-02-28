using FluentValidation;

namespace Ambev.DeveloperEvaluation.Application.Products.CreateProduct;

/// <summary>
/// Validator for CreateProductCommand that defines validation rules for user creation command.
/// </summary>
public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    /// <summary>
    /// Initializes a new instance of the CreateProductCommandValidator with defined validation rules.
    /// </summary>
    public CreateProductCommandValidator()
    {
        RuleFor(product => product.Price).GreaterThan(0);
        RuleFor(product => product.Title).NotEmpty().Length(3, 50);
        RuleFor(product => product.Category).NotEmpty().Length(3, 50);
        RuleFor(product => product.Description).NotEmpty().MinimumLength(10);
    }
}