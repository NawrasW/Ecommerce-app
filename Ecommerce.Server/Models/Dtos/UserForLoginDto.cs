namespace Ecommerce.Server.Models.Dtos
{
    public class UserForLoginDto
    {

        public string Email { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
        }

        public class UserLoginDto
        {
            //public UserLoginDto() { }

            //public UserLoginDto(int id ,string? username, string firstName, string lastName)
            //{
            //    Id = id;
            //    UserName = username;
            //    FirstName = firstName;
            //    LastName = lastName;
            //}


            public int Id { get; set; }
            public string Email { get; set; } = string.Empty;



            public string FirstName { get; set; } = string.Empty;

            public string LastName { get; set; } = string.Empty;

            public string Token { get; set; } = string.Empty;

            public string Role { get; set; } = string.Empty;
        }
    }

