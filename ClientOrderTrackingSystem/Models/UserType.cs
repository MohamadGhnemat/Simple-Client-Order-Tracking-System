using System.ComponentModel.DataAnnotations;

namespace ClientOrderTrackingSystem.Models
{
    public class UserType
    {
        public int UserTypeId { get; set; }

        [MaxLength(100)]
        public required string UserTypeName { get; set; }
    }
}
