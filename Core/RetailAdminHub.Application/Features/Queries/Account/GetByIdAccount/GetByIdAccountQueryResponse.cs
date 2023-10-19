using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Account.GetByIdAccount;

public class GetByIdAccountQueryResponse
{
    public Guid Id { get; set; }
    public int AccountNumber { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public DateTime LastActivityDate { get; set; }
    public DateTime InsertDate { get; set; }
    virtual public DateTime? UpdateDate { get; set; }
}

