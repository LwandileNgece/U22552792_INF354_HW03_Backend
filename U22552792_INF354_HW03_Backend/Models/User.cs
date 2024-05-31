using System.ComponentModel.DataAnnotations;

namespace U22552792_INF354_HW03_Backend.Models
{
    public class User
    {
        public int UserId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
