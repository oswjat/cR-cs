using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Models
{
    public partial class ListedProduct
    {
        public int Id { get; set; }
        public int ShoppingListId { get; set; }
        public int ProductId { get; set; }
        public bool? IsBought { get; set; }
        public int? AvgBuyingQuantity { get; set; }

        public virtual Product Product { get; set; }
        public virtual ShopList ShoppingList { get; set; }
    }
}
