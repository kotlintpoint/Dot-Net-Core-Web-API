using System.Security.Claims;
using Application.DTOs;
using GetriWebApi.Models;
using GetriWebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace GetriWebApi.Controllers
{
    [AllowAnonymous]
    public class AccountController : BaseApiController
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly TokenService _tokenService;

        public AccountController(UserManager<AppUser> userManager, TokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result)
            {
                return CreateUserObject(user);
            }
            return Unauthorized();
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<UserDto>> GetCurrentUser()
        {
            var user = await _userManager.FindByEmailAsync(User.FindFirstValue(ClaimTypes.Email));

            return new UserDto {
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                Image = null,
                Token = null
            };
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegistrationDto registrationDto)
        {
            if(await _userManager.Users.AnyAsync(u => u.UserName == registrationDto.UserName))
            {
                ModelState.AddModelError("username", "Username already taken.");
                return ValidationProblem();
            }

            if (await _userManager.Users.AnyAsync(u => u.Email == registrationDto.Email))
            {
                ModelState.AddModelError("email", "Email already taken.");
                return ValidationProblem();
            }

            var appUser = new AppUser
            {
                UserName = registrationDto.UserName,
                Email = registrationDto.Email,
                DisplayName = registrationDto.DisplayName,
                Bio = registrationDto.Bio
            };
            var result = await _userManager.CreateAsync(appUser, registrationDto.Password);
            if (result.Succeeded)
            {
                return CreateUserObject(appUser);
            }
            return BadRequest(result.Errors);
        }

        private UserDto CreateUserObject(AppUser user) {
            return new UserDto
            {
                UserName = user.UserName,
                DisplayName = user.DisplayName,
                Image = null,
                Token = _tokenService.CreateToken(user),
            };
        }
    }
}
