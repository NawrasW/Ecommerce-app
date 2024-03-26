using Ecommerce.Server.Models.Dtos;

namespace Ecommerce.Server.Repsitories.Abstrarct
{
    public interface IUserRepsitory
    {

        Task<bool> AddUpdateUser(UserDto user);

        Task<List<UserDto>> GetAllUser();

        Task<bool> DeleteUser(int id);

        Task<UserDto> GetUserById(int id);

        Task<UserLoginResponseDto> GetLoginUser(UserLoginReqDto user);
    }
}
