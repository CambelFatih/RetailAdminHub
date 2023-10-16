using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Persistence.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly RetailAdminHubDbContext dbContext;

    public UnitOfWork(RetailAdminHubDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public void Complete()
    {
        dbContext.SaveChanges();
    }

    public void CompleteTransaction()
    {
        using (var transaction = dbContext.Database.BeginTransaction())
        {
            try
            {
                dbContext.SaveChanges();
                transaction.Commit();
            }
            catch (Exception ex)
            {
                transaction.Rollback();
               // Log.Error("CompleteTransactionError", ex); 
            }
        }
    }
}

