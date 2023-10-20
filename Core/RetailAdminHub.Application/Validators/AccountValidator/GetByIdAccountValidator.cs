using FluentValidation;
using RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;

namespace RetailAdminHub.Application.Validators.AccountValidator;

public class GetByIdAccountValidator: AbstractValidator<GetByIdAccountQueryRequest>
{
    public GetByIdAccountValidator()
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

