﻿namespace Ecommerce.Server.Models.Dtos
{
  
        public class UserLoginReqDto
        {
            public string? Email { get; set; } = string.Empty;
            public string? Password { get; set; } = string.Empty;
        }


        public class UserLoginResponseDto
        {
            public int Id { get; set; }

            public string? FirstName { get; set; }

            public string? LastName { get; set; }
        }
    }

