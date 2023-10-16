
namespace RetailAdminHub.Application.Features.Queries.Account.GetAllAccount;

public class GetAllAccountQueryResponse 
{
    public Guid Id { get; set; }
    public int AccountNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Role { get; set; }
    public DateTime LastActivityDate { get; set; }
    public DateTime InsertDate { get; set; }
    virtual public DateTime? UpdateDate { get; set; }
}

