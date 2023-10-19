
namespace RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;

public class GetAllAccountQueryResponse 
{
    public Guid Id { get; set; }
    public int AccountNumber { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
}

