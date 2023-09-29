using RetailAdminHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Repositories
{
    public interface IProductReadRepository : IReadRepository<Product>
    {
        void Deneme();
    }
}
