using FluentValidation;
using RetailAdminHub.Application.Features.Command.Product.PatchProduct;

namespace RetailAdminHub.Application.Validators.Products;

public class PatchProductValidator : AbstractValidator<PatchProductCommandRequest>
{
    public PatchProductValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Product name cannot be empty.");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}

