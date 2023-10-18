using RetailAdminHub.Application.Abstractions.Services;
using RetailAdminHub.Application.Abstractions.Uow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Persistence.Services;

public class AccountService : IAccountService
{
    private readonly IUnitOfWork unitOfWork;

    public AccountService(IUnitOfWork unitOfWork)
    {
        this.unitOfWork = unitOfWork;
    }
}

