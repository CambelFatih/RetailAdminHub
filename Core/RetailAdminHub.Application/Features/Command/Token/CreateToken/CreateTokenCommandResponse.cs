
namespace RetailAdminHub.Application.Features.Command.Token.CreateToken;

public class CreateTokenCommandResponse
{
    public DateTime ExpireDate { get; set; }
    public string Token { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int AccountNumber { get; set; }
}

