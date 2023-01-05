using API.Entities;

namespace API.DTOs
{
    public class ShoppingCartDto
    {
        
        public int Id { get; set; }
        public int Quantity { get; set; }
        public decimal TotalCost { get; set; }
        public int UserId { get; set; }
        public  User User { get; set; }
        public Product Product { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }
}