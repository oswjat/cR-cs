using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public partial class Product
    {
        public Product()
        {
            ListedProducts = new HashSet<ListedProduct>();
        }

        public int Id { get; set; }

        public string Name { get; set; }
        public int? Price { get; set; }
        public int? ShelfId { get; set; }
        public DateTime? Warranty { get; set; }

        public virtual Shelf Shelf { get; set; }
        public virtual ICollection<ListedProduct> ListedProducts { get; set; }
    }
}
