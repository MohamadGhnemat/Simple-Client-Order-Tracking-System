using System.ComponentModel.DataAnnotations;

namespace ClientOrderTrackingSystem.Models
{
    public class Product
    {
        
        public int ProductId { get; set; }

        [MaxLength(100)]
        public required string ProductName { get; set; }
        public int Price { get; set; }
    }
}
