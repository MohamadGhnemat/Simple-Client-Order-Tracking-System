using System.ComponentModel.DataAnnotations;

namespace ClientOrderTrackingSystem.Models
{
    public class User
    {
        public int UserId { get; set; }

        [MaxLength(100)]
        public required string UserName { get; set; }

        [MaxLength(100)]
        
        public required string UserPassword { get; set; }

 
        [MaxLength(100)]
        public required string Email { get; set; }
        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }
    }
}
