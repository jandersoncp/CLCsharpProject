using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GroceryApp.Models
{
    public class GroceryAppContext : DbContext
    {
        public GroceryAppContext (DbContextOptions<GroceryAppContext> options)
            : base(options)
        {
        }

        public DbSet<GroceryApp.Models.GroceryItems> GroceryItems { get; set; }
    }
}
