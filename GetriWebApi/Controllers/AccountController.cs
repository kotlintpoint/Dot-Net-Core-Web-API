using Application.DTOs;
using GetriWebApi.Models;
using GetriWebApi.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GetriWebApi.Controllers
{
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
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto) { 

            var user = await _userManager.FindByEmailAsync(loginDto.Email);
            if (user == null)
            {
                return Unauthorized();
            }

            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);
            if (result) {
                return new UserDto
                {
                    DisplayName = user.DisplayName,
                    UserName = user.UserName,
                    Token = _tokenService.CreateToken(user),
                    Image = null
                };
            }
            return Unauthorized();
        }
    }
}
