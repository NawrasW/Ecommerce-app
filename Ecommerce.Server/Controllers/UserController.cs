using Ecommerce.Server.Models.Dtos;
using Ecommerce.Server.Repsitories.Abstrarct;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepsitory _userRepsitory;

        public UserController(IUserRepsitory userRepsitory)
        {
            _userRepsitory = userRepsitory;


        }

        [HttpPost("AddUpdateUser")]

        public async Task<IActionResult> AddUpdateUser(UserDto user)
        {
            var result = await _userRepsitory.AddUpdateUser(user);
            var status = new Status
            {

                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Saved Successfully" : "Error Adding......."


            };
            return Ok(status);
        }



        [HttpGet("getAllUser")]
        public async Task<IActionResult> GetAllUser()

        {
            var result = await _userRepsitory.GetAllUser();
            return Ok(result);
        }



        [HttpDelete("deleteUser/{id}")]   //api/User/deleteUser/2  for example
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _userRepsitory.DeleteUser(id);
            var status = new Status
            {
                StatusCode = result ? 1 : 0,
                StatusMessage = result ? "Deleted Successfully" : "Error Deleting......"

            };
            return Ok(status);
        }

        [HttpGet("getUserById/{id}")]

        public async Task<IActionResult> GetUserById(int id)
        {

            var user = await _userRepsitory.GetUserById(id);
            return Ok(user);



        }


        [HttpPost("getLoginUser")]
        public async Task<UserLoginResponseDto> GetLoginUser(UserLoginReqDto user)
        {
            var result = await _userRepsitory.GetLoginUser(user);

            return result;

        }

    }

}


