using RetailAdminHub.Application.Repositories.CategoryRepository;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Persistence.Contexts;

namespace RetailAdminHub.Persistence.Repositories.CategoryRepository;

public class CategoryWriteRepository : WriteRepository<Category>, ICategoryWriteRepository
{
    public CategoryWriteRepository(RetailAdminHubDbContext context) : base(context)
    {
    }
}

