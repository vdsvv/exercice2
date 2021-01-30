using System;
using System.Threading.Tasks;
using Contracts;
using Mapping;
using Microsoft.AspNetCore.Mvc;
using Services;
using Validation;

namespace Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet(ApiRoutes.Users.Get)]
        public async Task<IActionResult> Get([FromRoute]Guid userId)
        {
            var user = await _userService.GetUserByIdAsync(userId);
            if (user == null)
                return NotFound();
            return Ok(user);
        }

        [HttpPut(ApiRoutes.Users.Update)]
        public async Task<IActionResult> Update([FromRoute]Guid userId, [FromBody] UserRequest request)
        {
            if(!UserValidation.Valid(request))
            {
                return BadRequest();
            }
            var user = UserMapper.FromRequest(userId, request);
            var updated = await _userService.UpdateUserAsync(user);
            if(updated)
            {
                var response = UserMapper.ToResponse(user);
                return Ok(response);
            }
            return NotFound();
        }

        [HttpGet(ApiRoutes.Users.GetAll)]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetUsersAsync();
            return Ok(users);
        }

        [HttpPost(ApiRoutes.Users.Create)]
        public async Task<IActionResult> Create([FromBody] UserRequest request)
        {   
            if(!UserValidation.Valid(request))
            {
                return BadRequest();
            }
            var user = UserMapper.FromRequest(Guid.NewGuid(), request);
            await _userService.CreateUserAsync(user);
            var response = UserMapper.ToResponse(user);
            return Ok(response);
        }

        [HttpDelete(ApiRoutes.Users.Delete)]
        public async Task<IActionResult> Delete([FromRoute] Guid userId)
        {
            var deleted = await _userService.DeleteUserAsync(userId);
            if (deleted)
                return NoContent();
            return NotFound();
        }
    }
}