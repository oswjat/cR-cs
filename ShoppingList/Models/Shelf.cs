using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public partial class Shelf
    {
        public Shelf()
        {
            Products = new HashSet<Product>();
        }

        
        public int Id { get; set; }

        public string Category { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
