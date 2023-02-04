using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol.Plugins;
using BCryptNet = BCrypt.Net.BCrypt;
using NewRepo.Helpers.Attributes;
using NewRepo.Models;
using NewRepo.Models.DTOs.UserDTO;
using NewRepo.Models.Enums;
using NewRepo.Services.UserService;

namespace NewRepo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateAdmin(ContRequestDTO user)
        {
            await _userService.CreateAdmin(user);
            return Ok();
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateUser(ContRequestDTO user)
        {
            await _userService.CreateUser(user);
            return Ok();
        }

        [HttpPost("create-user")]
        public async Task<IActionResult> CreateEmployee(ContRequestDTO user)
        {
            await _userService.CreateEmployee(user);
            return Ok();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(ContRequestDTO user)
        {
            var response = _userService.Authenticate(user);
            if (user == null)
            {
                return BadRequest("Invalid username or password!");
            }

            return Ok();
        }

        [HttpDelete("{username}")]
        public async Task<IActionResult> Delete(string email)
        {
            var result = _userService.DeleteByEmailAsync(email);
            if (result == null)
            {
                return BadRequest("Username does not exist!");
            }

            return Ok();
        }

        [HttpGet("{username}")]
        public async Task<IActionResult> GetUser(string username)
        {
            var user = await _userService.GetAllUsers();
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }

        [Authorization(Role.Admin)]
        [HttpGet("admin")]
        public IActionResult GetSomeAdmin()
        {
            var admins = _userService.GetSomeAdmins();
            return Ok(admins);
        }
    }
}