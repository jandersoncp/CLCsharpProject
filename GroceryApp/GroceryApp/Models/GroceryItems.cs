using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GroceryApp.Models
{
    public class GroceryItems
    {
        public int Id { get; set; }
        public string Item { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
    }
}
