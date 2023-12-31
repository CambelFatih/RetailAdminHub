﻿using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Persistence.Contexts;

namespace RetailAdminHub.Persistence.Repositories.AccountRepository;

public class AccountReadRepository : ReadRepository<Account>, IAccountReadRepository
{
    readonly private RetailAdminHubDbContext context;
    public AccountReadRepository(RetailAdminHubDbContext context) : base(context)
    {
        this.context = context;
    }
}

