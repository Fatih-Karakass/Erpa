using ErpaHoldingFatihKarakas.Domain.Authentication.Dto;
using ErpaHoldingFatihKarakas.Domain.Token;

namespace ErpaHoldingFatihKarakas.Domain.Repositories
{
    public interface IAuthenticationService
    {

        Task<TokenDto> CreateTokenAsync(LoginDto loginDto);

        Task<TokenDto> CreateTokenByRefreshToken(string refreshToken);

        Task RevokeRefreshToken(string refreshToken);


    }
}
