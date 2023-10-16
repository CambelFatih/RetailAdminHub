
using MediatR;
using RetailAdminHub.Domain.Response;

namespace RetailAdminHub.Application.Features.Command.Account.UpdateAccount;

public class UpdateAccountCommandRequest : IRequest<ApiResponse<UpdateAccountCommandResponse>>
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
}

