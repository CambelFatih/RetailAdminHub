using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Exceptions;
using RetailAdminHub.Application.Repositories;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Persistence.Repositories
{
    public class ProductReadRepository : ReadRepository<Product>, IProductReadRepository
    {
        readonly private RetailAdminHubDbContext _context;
        public ProductReadRepository(RetailAdminHubDbContext context) : base(context)
        {
            _context = context;
        }
        public async Task<Product>? GetProductWithCategoriesAsync(string productId)
        {
            if (!Guid.TryParse(productId, out Guid parsedId))
            {
                throw new InvalidGuidException();
            }
            return await _context.Products
                .Include(p => p.Categories)
                .FirstOrDefaultAsync(p => p.Id == parsedId);
        }
        public async Task<List<Product>> GetProductsPagedWithCategoriesAsync(int page, int size)
        {
            return await _context.Products
                                 .Include(p => p.Categories)
                                 .Skip(page * size)
                                 .Take(size)
                                 .ToListAsync();
        }

    }
}
