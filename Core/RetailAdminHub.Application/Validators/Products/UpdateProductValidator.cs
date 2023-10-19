using FluentValidation;
using RetailAdminHub.Application.Features.Command.Product.UpdateProduct;

namespace RetailAdminHub.Application.Validators.Products;

public class UpdateProductValidator : AbstractValidator<UpdateProductCommandRequest>
{
    public UpdateProductValidator()
    {
        RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Product name cannot be empty.");

        RuleFor(x => x.Stock)
            .GreaterThanOrEqualTo(0).WithMessage("Stock quantity cannot be negative.");

        RuleFor(x => x.Price)
            .GreaterThan(0).WithMessage("Price must be greater than 0.");
    }
}

