using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Entities
{
    public class ShoppingCart
    {

        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public User UserId { get; set; }
        public User User { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();

    }
}