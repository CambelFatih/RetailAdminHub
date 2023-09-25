using RetailAdminHub.Domain.Entities.Common;
using System.Collections.Generic;

namespace RetailAdminHub.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        // ManyToMany ili�kisi i�in bir koleksiyon
        public ICollection<Category> Categories { get; set; }
    }
}
