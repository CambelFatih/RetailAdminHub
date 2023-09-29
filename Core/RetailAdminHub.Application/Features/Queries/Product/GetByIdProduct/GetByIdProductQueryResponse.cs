using RetailAdminHub.Application.DTOs.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using C = RetailAdminHub.Domain.Entities;
namespace RetailAdminHub.Application.Features.Queries.Product.GetByIdProduct
{
    public class GetByIdProductQueryResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; } // CategoryDTO'yu kullanın
    }
}
