using Microsoft.EntityFrameworkCore.Storage;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Persistence.Contexts;
using RetailAdminHub.Persistence.Repositories.AccountRepository;
using RetailAdminHub.Persistence.Repositories.CategoryRepository;
using RetailAdminHub.Persistence.Repositories.ProductRepository;

namespace RetailAdminHub.Persistence.Uow;

public class UnitOfWork : IUnitOfWork
{
    private readonly RetailAdminHubDbContext dbContext;
    private IDbContextTransaction transaction;

    public UnitOfWork(RetailAdminHubDbContext dbContext)
    {
        this.dbContext = dbContext;
        ProductReadRepository = new ProductReadRepository(dbContext);
        CategoryReadRepository = new CategoryReadRepository(dbContext);
        AccountReadRepository = new AccountReadRepository(dbContext);
        ProductWriteRepository = new ProductWriteRepository(dbContext);
        CategoryWriteRepository = new CategoryWriteRepository(dbContext);
        AccountWriteRepository = new AccountWriteRepository(dbContext);
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
    public IDbContextTransaction BeginTransaction()
    {
        return dbContext.Database.BeginTransaction();
    }
    public IProductReadRepository ProductReadRepository { get; private set; }
    public ICategoryReadRepository CategoryReadRepository { get; private set; }
    public IAccountReadRepository AccountReadRepository { get; private set; }
    public IProductWriteRepository ProductWriteRepository { get; private set; }
    public ICategoryWriteRepository CategoryWriteRepository { get; private set; }
    public IAccountWriteRepository AccountWriteRepository { get; private set; }
}

