using System.ComponentModel.DataAnnotations;

namespace Ecommerce.Server.Models.Domain
{
    public class User
    {
        public User() { }
        public int Id { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public string? Email { get; set; }


        public byte[] Password { get; set; }
        public byte[] PasswordKey { get; set; }


        public string? PhoneNumber { get; set; }

        public DateTime? DateOfBirth { get; set; } // User's date of birth

        public string? Address { get; set; } // User's address

        public string? City { get; set; } // User's city

        //[Required]
        //public string? Username { get; set; }


        //public string? State { get; set; } // User's state

        //public string? ZipCode { get; set; } // User's zip code


        /* public ICollection<Order> Orders { get; set; }*/ // User's orders (assuming you have an Order model)

        public string? Role { get; set; }


        public string? Token { get; set; }

    }
}
