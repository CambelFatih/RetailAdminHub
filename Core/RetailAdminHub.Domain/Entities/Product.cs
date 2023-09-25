using RetailAdminHub.Domain.Entities.Common;
using System.Collections.Generic;

namespace RetailAdminHub.Domain.Entities
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public int Stock { get; set; }
        public float Price { get; set; }
        // ManyToMany iliþkisi için bir koleksiyon
        public ICollection<Category> Categories { get; set; }
    }
}
