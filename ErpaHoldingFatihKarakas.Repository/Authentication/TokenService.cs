using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Token;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ErpaHoldingFatihKarakas.Repository.Authentication
{
    public class TokenService : ITokenService
    {
        private readonly UserManager<User> _userManager;

        private readonly CustomTokenOption _tokenOption;

        public TokenService(UserManager<User> userManager, IOptions<CustomTokenOption> options)
        {
            _userManager = userManager;
            _tokenOption = options.Value;
        }

        private string CreateRefreshToken()

        {
            var numberByte = new Byte[32];

            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        private async Task<IEnumerable<Claim>> GetClaims(User userApp)
        {
            var userList = new List<Claim> {
            new Claim(ClaimTypes.NameIdentifier,userApp.Id.ToString()),
            new Claim(JwtRegisteredClaimNames.Email, userApp.Email),
            new Claim(ClaimTypes.Name,userApp.UserName),
            new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString())

            };
            var roles = await _userManager.GetRolesAsync(userApp);
            userList.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));



            return userList;
        }


        public async Task<TokenDto> CreateToken(User userApp)
        {
            var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.AccessTokenExpiration);
            var refreshTokenExpiration = DateTime.Now.AddMinutes(_tokenOption.RefreshTokenExpiration);
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("mysecuritykeymysecuritykeymysecuritykeymysecuritykey"));


            SigningCredentials signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
                issuer: _tokenOption.Issuer,
                expires: accessTokenExpiration,
                 notBefore: DateTime.Now,
                 claims: await GetClaims(userApp),
                 signingCredentials: signingCredentials);

            var handler = new JwtSecurityTokenHandler();

            var token = handler.WriteToken(jwtSecurityToken);

            var tokenDto = new TokenDto
            {
                AccessToken = token,
                RefreshToken = CreateRefreshToken(),
                AccessTokenExpiration = accessTokenExpiration,
                RefreshTokenExpiration = refreshTokenExpiration
            };

            return tokenDto;
        }
    }
}
