using Microsoft.EntityFrameworkCore;
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
    public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
    {
        readonly private RetailAdminHubDbContext _context;
        public ProductWriteRepository(RetailAdminHubDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddProductWithCategories(Product product, List<Category> categories)
        {
            product.Categories = categories;
            _context.Products.Add(product);
            await _context.SaveChangesAsync();
        }

    }
}
