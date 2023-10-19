using FluentValidation;
using RetailAdminHub.Application.Features.Command.Account.CreateAccount;

namespace RetailAdminHub.Application.Validators.AccountValidator
{
    public class CreateAccountValidator : AbstractValidator<CreateAccountCommandRequest>
    {
        public CreateAccountValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email cannot be empty.")
                .EmailAddress().WithMessage("Please enter a valid email address.");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password cannot be empty.")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long.");

            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage("First name cannot be empty.")
                .MaximumLength(50).WithMessage("First name can be up to 50 characters long.");

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage("Last name cannot be empty.")
                .MaximumLength(50).WithMessage("Last name can be up to 50 characters long.");
        }
    }
}
