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
        public async void Deneme()
        {
           Product product = new Product { Name = "product-1", Stock = 4, Price = 4.3f };
           Category category1 = new Category { Name="category-1", Description="description-1"};
           Category category2 = new Category { Name = "category-2", Description = "description-2" };
           product.Categories.Add(category1);
           product.Categories.Add(category2);
           await _context.SaveChangesAsync();
        }
    }
}
