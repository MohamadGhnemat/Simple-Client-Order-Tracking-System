using ClientOrderTrackingSystem.Models;
using System.ComponentModel.DataAnnotations;

namespace ClientOrderTrackingSystem.ViewModels
{
    public class VwUserUserType
    {
        public int UserId { get; set; }

        [MaxLength(100)]
        public  string UserName { get; set; }

        [MaxLength(100)]

        public  string UserPassword { get; set; }


        [MaxLength(100)]
        public string Email { get; set; }
        public int UserTypeId { get; set; }

        public UserType UserType { get; set; }
        public List<UserType> lstUserTypes { get; set; }
    }
}
