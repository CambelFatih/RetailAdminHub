using RetailAdminHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Repositories.ProductRepository
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
        public Task<Product>? GetProductWithCategoriesAsync(string productId , CancellationToken cancellationToken);
        public Task<List<Product>> GetProductsPagedWithCategoriesAsync(int page, int size, CancellationToken cancellationToken);
    }
}
