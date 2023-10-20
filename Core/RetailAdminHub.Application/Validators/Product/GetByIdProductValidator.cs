using FluentValidation;
using RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct;

namespace RetailAdminHub.Application.Validators.Product;

public class GetByIdProductValidator:AbstractValidator<GetByIdProductQueryRequest>
{
    public GetByIdProductValidator()
    {
        RuleFor(entity => entity.Id)
            .NotEmpty().WithMessage("Id can't be empty.")
            .Must(BeValidGuid).WithMessage("Id is not a valid GUID.");
    }

    private bool BeValidGuid(string id)
    {
        return Guid.TryParse(id, out _);
    }
}

