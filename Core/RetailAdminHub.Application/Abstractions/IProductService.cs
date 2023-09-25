using RetailAdminHub.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Abstractions
{
    public  interface  IProductService
    {
        List<Product> GetProducts();
    }
}
