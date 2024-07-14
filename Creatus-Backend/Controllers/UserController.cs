using Microsoft.AspNetCore.Mvc;
using creatus_backend.Dtos.Request;
using creatus_backend.Dtos.Response;
using creatus_backend.Exceptions;
using creatus_backend.Services;
using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace creatus_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            try
            {
                var users = await _userService.GetAllUsers();
                return Ok(users);
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            try
            {
                var user = await _userService.GetById(id);
                return Ok(user);
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] UserRequest userRequest)
        {
            try
            {
                var newUser = await _userService.CreateUser(userRequest);
                return Ok(newUser);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserRequest userRequest)
        {
            if (userRequest == null)
            {
                return BadRequest();
            }

            try
            {
                var updatedUser = await _userService.UpdateUser(id, userRequest);
                return Ok(updatedUser);
            }
            catch (Exception e)
            {
                return BadRequest(new { message = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                await _userService.DeleteUser(id);
                return NoContent();
            }
            catch (Exception e)
            {
                return NotFound(new { message = e.Message });
            }
        }

        [Authorize]
        [HttpGet("report")]
        [Authorize(Policy = "RequireLevel4")]
        public IActionResult GenerateReport()
        {
             try
            {
                _userService.GeneratePdfReport();
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, new { message = "Erro ao gerar relatório PDF", error = e.Message });
            }
        }
    }
}
