using RetailAdminHub.Application.DTOs.Product;
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
        public List<ProductDetailDTO> Products { get; set; }
    }
}
