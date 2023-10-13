using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RetailAdminHub.Application.Abstractions.Services;
using RetailAdminHub.Application.Repositories.ProductRepository;

namespace RetailAdminHub.Persistence.Services
{
    public class ProductService : IProductService
    {
        readonly IProductReadRepository productReadRepository;
        readonly IProductWriteRepository productWriteRepository;

        public ProductService(IProductReadRepository productReadRepository, IProductWriteRepository productWriteRepository)
        {
            this.productReadRepository = productReadRepository;         
            this.productWriteRepository = productWriteRepository;
        }
    }
}
