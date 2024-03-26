using Ecommerce.Server.Models.Dtos;

namespace Ecommerce.Server.Repsitories.Abstrarct
{
    public interface IAuthRepsitory
    {
        Task<UserLoginDto> Login(UserForLoginDto userDto);

        Task<bool> Register(UserDto userDto);


        Task<bool> UserAlreadyExists(string userName);
    }
}
