using FluentValidation;
using RetailAdminHub.Application.Features.Queries.Category.GetByIdCategory;

namespace RetailAdminHub.Application.Validators.CategoryValidator;

public class GetByIdCategoryValidator : AbstractValidator<GetByIdCategoryQueryRequest>
{
    public GetByIdCategoryValidator()
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


