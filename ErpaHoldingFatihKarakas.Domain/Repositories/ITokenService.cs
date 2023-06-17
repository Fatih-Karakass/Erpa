using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Token;

namespace ErpaHoldingFatihKarakas.Domain.Repositories
{
    public interface ITokenService
    {
        Task<TokenDto> CreateToken(User userApp);


    }
}
