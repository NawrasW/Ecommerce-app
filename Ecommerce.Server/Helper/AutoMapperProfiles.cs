using AutoMapper;
using Ecommerce.Server.Models.Domain;
using Ecommerce.Server.Models.Dtos;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Ecommerce.Server.Helper
{

        public class AutoMapperProfiles : Profile
        {

            public AutoMapperProfiles()
            {
                CreateMap<User, UserDto>().ReverseMap();
                //CreateMap<UserDto, User>();

            }

        }
    }

