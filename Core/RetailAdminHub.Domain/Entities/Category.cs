using RetailAdminHub.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RetailAdminHub.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }

        // ManyToMany ilişkisi için bir koleksiyon
        public ICollection<Product> Products { get; set; }
    }
}
