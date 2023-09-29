using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Exceptions;
using RetailAdminHub.Application.Repositories;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Persistence.Repositories
{
    public class CategoryReadRepository : ReadRepository<Category>, ICategoryReadRepository
    {
        private readonly RetailAdminHubDbContext _context;
        public CategoryReadRepository(RetailAdminHubDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Category> GetCategoryWithProductsAsync(string categoryId)
        {
            if (!Guid.TryParse(categoryId, out Guid parsedId))
            {
                throw new InvalidGuidException();
            }
            return await _context.Categories
                .Include(c => c.Products) // Ürünleri dahil ediyoruz.
                .FirstOrDefaultAsync(c => c.Id == parsedId);
        }
    }
}
