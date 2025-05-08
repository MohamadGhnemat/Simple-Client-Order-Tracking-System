using System.ComponentModel.DataAnnotations;

namespace ClientOrderTrackingSystem.Models
{
    public class Client
    {
        public int ClientId { get; set; }

        [MaxLength(100)]
        public required string ClientName { get; set; }
    }
}
