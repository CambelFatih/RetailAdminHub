using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.Features.Queries.Product.CreateProduct
{
    public class GetAllProductQueryResponse
    {
        public int TotalProductCount { get; set; }
        public object Products { get; set; }
    }
}
