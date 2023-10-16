
namespace RetailAdminHub.Application.Features.Command.Token.CreateToken;

public class CreateTokenCommandResponse
{
    public DateTime ExpireDate { get; set; }
    public string Token { get; set; }
    public string Email { get; set; }
    public int AccountNumber { get; set; }
}

