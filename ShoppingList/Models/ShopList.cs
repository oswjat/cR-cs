using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public partial class ShopList
    {
        public ShopList()
        {
            ListedProducts = new HashSet<ListedProduct>();
        }

        public int Id { get; set; }
        public string ListName { get; set; }
        public DateTime? CreatingDate { get; set; }
        public int? Price { get; set; }
        public string UserId { get; set; }

        public virtual ICollection<ListedProduct> ListedProducts { get; set; }
    }
}
