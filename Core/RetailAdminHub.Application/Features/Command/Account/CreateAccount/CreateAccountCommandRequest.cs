using MediatR;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.Account.CreateAccount;

public class CreateAccountCommandRequest : IRequest<ApiResponse<CreateAccountCommandResponse>>
{
    public string Name { get; set; }
    public decimal Balance { get; set; }
}

