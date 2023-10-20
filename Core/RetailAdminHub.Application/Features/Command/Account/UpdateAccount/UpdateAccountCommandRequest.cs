
using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Account.UpdateAccount;

public class UpdateAccountCommandRequest : IRequest<ApiResponse<UpdateAccountCommandResponse>>
{
    public string Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

