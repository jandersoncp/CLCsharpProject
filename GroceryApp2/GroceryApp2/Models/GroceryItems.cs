using System.Data.Entity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.Infrastructure;

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
