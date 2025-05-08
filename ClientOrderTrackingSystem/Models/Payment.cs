using System.ComponentModel.DataAnnotations;

namespace ClientOrderTrackingSystem.Models
{
    public class Payment
    {
        [Key]
        public int PaymentTypeId { get; set; }

        [MaxLength(100)]
        public required string PaymentTypeName { get; set; }
    }
}
