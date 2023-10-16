using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Domain.Base.Response;
using RetailAdminHub.Persistence.Contexts;
using System.Net;
using System.Threading;

namespace RetailAdminHub.Persistence.Repositories.AccountRepository;

public class AccountWriteRepository : WriteRepository<Account>, IAccountWriteRepository
{
    readonly private RetailAdminHubDbContext context;
    public AccountWriteRepository(RetailAdminHubDbContext context) : base(context)
    {
        this.context = context;
    }

}

