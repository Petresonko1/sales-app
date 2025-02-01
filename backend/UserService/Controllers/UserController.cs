using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using Grpc.Net.Client;
using UserService.Protos;

namespace UserService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService.UserServiceClient _userServiceClient;

        public UserController(UserService.UserServiceClient userServiceClient)
        {
            _userServiceClient = userServiceClient;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var request = new GetUsersRequest();
            var response = await _userServiceClient.GetUsersAsync(request);
            return Ok(response.Users);
        }

        [HttpPost]
        public async Task<ActionResult<User>> CreateUser([FromBody] CreateUserRequest createUserRequest)
        {
            var response = await _userServiceClient.CreateUserAsync(createUserRequest);
            return CreatedAtAction(nameof(GetUsers), new { id = response.User.Id }, response.User);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<User>> UpdateUser(string id, [FromBody] UpdateUserRequest updateUserRequest)
        {
            updateUserRequest.Id = id;
            var response = await _userServiceClient.UpdateUserAsync(updateUserRequest);
            return Ok(response.User);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var request = new DeleteUserRequest { Id = id };
            await _userServiceClient.DeleteUserAsync(request);
            return NoContent();
        }
    }
}