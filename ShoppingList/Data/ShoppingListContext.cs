using Microsoft.EntityFrameworkCore;
using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShoppingList.Data
{
    public class ShoppingListContext : DbContext
    {
        public ShoppingListContext(DbContextOptions<ShoppingListContext> options)
            : base(options)
        {
        }

        public DbSet<ListedProduct> ListedProduct { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Shelf> Shelfs { get; set; }
        public DbSet<ShopList> ShopList { get; set; }
    }
}
