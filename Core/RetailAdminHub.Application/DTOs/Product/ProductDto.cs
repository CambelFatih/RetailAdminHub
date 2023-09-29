using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Application.DTOs.Product
{
    public class ProductDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        public ICollection<CategoryDTO> Categories { get; set; }
    }

    public class CategoryDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
