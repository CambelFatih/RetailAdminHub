
using MediatR;
using RetailAdminHub.Domain.Base.Response;

namespace RetailAdminHub.Application.Features.Command.Token.CreateToken;

public class CreateTokenCommandRequest : IRequest<ApiResponse<CreateTokenCommandResponse>>
{
    public int AccountNumber { get; set; }
    public string Password { get; set; } = string.Empty;
}

