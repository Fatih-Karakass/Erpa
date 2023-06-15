using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Authentication.Dto;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ErpaHoldingFatihKarakas.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<Role> _roleManager;

        public AuthController(IAuthenticationService authenticationService, UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            _authenticationService = authenticationService;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        //api/auth/
        [HttpPost]
        public async Task<IActionResult> CreateToken(LoginDto loginDto)
        {
            var result = await _authenticationService.CreateTokenAsync(loginDto);

          
            return Ok(result);
        }

   
        [HttpPost]
        public async Task<IActionResult> RevokeRefreshToken(RefreshTokenDto refreshTokenDto)
        {
            await _authenticationService.RevokeRefreshToken(refreshTokenDto.Token);

            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> CreateTokenByRefreshToken(RefreshTokenDto refreshTokenDto)

        {
            var result = await _authenticationService.CreateTokenByRefreshToken(refreshTokenDto.Token);

            return Ok(result);
        }
        [HttpPost]

        public async Task<IActionResult> Register(UserDto userDto)
        {
            var User = new User
            {
                UserName = userDto.UserName,
                Email = userDto.Email,
                PhoneNumber = userDto.PhoneNumber,
                TcNo=userDto.TcNo
                
            };
            var result = await _userManager.CreateAsync(User, userDto.Password);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(User);
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleCreateDto roleDto)
        {
            var role = new Role
            {
                Name = roleDto.Name,
            };
            var result = await _roleManager.CreateAsync(role);
            if (!result.Succeeded)
            {
                return BadRequest(result);
            }
            return Ok(role);
        }
    }
}
