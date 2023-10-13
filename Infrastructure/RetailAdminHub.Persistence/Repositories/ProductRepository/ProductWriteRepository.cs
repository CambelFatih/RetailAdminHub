using Microsoft.EntityFrameworkCore;
using RetailAdminHub.Application.Features.Command.Product.RemoveProduct;
using RetailAdminHub.Application.Repositories.ProductRepository;
using RetailAdminHub.Domain.Entities;
using RetailAdminHub.Domain.Entities.Common;
using RetailAdminHub.Domain.Response;
using RetailAdminHub.Persistence.Contexts;
using System.Threading;

namespace RetailAdminHub.Persistence.Repositories.ProductRepository;

public class ProductWriteRepository : WriteRepository<Product>, IProductWriteRepository
{
    readonly private RetailAdminHubDbContext context;
    public ProductWriteRepository(RetailAdminHubDbContext context) : base(context)
    {
        this.context = context;
    }

    public async Task AddProductWithCategories(Product product, List<Category> categories)
    {
        product.Categories = categories;
        context.Products.Add(product);
        await context.SaveChangesAsync();
    }

}

