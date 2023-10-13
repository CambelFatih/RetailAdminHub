using FluentValidation;
using RetailAdminHub.Application.Features.Command.Product.CreateProduct;
namespace RetailAdminHub.Application.Validators.Products;
public class CreateProductValidator : AbstractValidator<CreateProductCommandRequest>
{
    public CreateProductValidator()
    {
        RuleFor(p => p.Name)
            .NotEmpty().NotNull().WithMessage("Product Name is required.")
            .MaximumLength(150).MinimumLength(5).WithMessage("Product Name should be between 5 to 150 characters.");

        RuleFor(p => p.Stock)
            .NotEmpty().NotNull().WithMessage("Stock value is required.")
            .Must(s => s > 0).WithMessage("Stock value must be positive.");

        RuleFor(p => p.Price)
            .NotEmpty().NotNull().WithMessage("Price is required.")
            .Must(s => s > 0).WithMessage("Price must be positive.");
    }
}

