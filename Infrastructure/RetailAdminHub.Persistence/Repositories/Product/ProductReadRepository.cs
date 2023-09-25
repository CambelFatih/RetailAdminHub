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
        public ProductReadRepository(RetailAdminHubDbContext context) : base(context)
        {
        }
    }
}
