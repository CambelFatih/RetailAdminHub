using Microsoft.EntityFrameworkCore.Storage;
using RetailAdminHub.Application.Abstractions.Services;
using RetailAdminHub.Application.Abstractions.Uow;
using RetailAdminHub.Application.Repositories.AccountRepository;
using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Persistence.Contexts;
using RetailAdminHub.Persistence.Repositories.AccountRepository;
using RetailAdminHub.Persistence.Repositories.CategoryRepository;
using RetailAdminHub.Persistence.Repositories.ProductRepository;
using RetailAdminHub.Persistence.Services;

namespace RetailAdminHub.Persistence.Uow;
/// <summary>
/// Represents a unit of work for database operations.
/// </summary>
public class UnitOfWork : IUnitOfWork
{
    private readonly RetailAdminHubDbContext dbContext;

    public UnitOfWork(RetailAdminHubDbContext dbContext)
    {
        this.dbContext = dbContext;
        ProductReadRepository = new ProductReadRepository(dbContext);
        CategoryReadRepository = new CategoryReadRepository(dbContext);
        AccountReadRepository = new AccountReadRepository(dbContext);
        ProductWriteRepository = new ProductWriteRepository(dbContext);
        CategoryWriteRepository = new CategoryWriteRepository(dbContext);
        AccountWriteRepository = new AccountWriteRepository(dbContext);
        AccountService = new AccountService(this);
        CategoryService = new CategoryService(this);
        ProductService = new ProductService(this);
    }
    /// <summary>
    /// Commits the pending changes to the database.
    /// </summary>
    public void Complete()
    {
        dbContext.SaveChanges();
    }
    /// <summary>
    /// Completes a transaction by committing or rolling back based on success or failure.
    /// </summary>
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
    public IAccountService AccountService { get; private set; }
    public IProductService ProductService { get; private set; }
    public ICategoryService CategoryService { get; private set; }
}

