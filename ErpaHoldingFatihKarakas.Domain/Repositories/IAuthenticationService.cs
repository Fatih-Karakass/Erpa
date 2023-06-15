using ErpaHoldingFatihKarakas.Domain.Authentication.Dto;
using ErpaHoldingFatihKarakas.Domain.Token;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Domain.Repositories
{
    public interface IAuthenticationService
    {
       
        Task<TokenDto> CreateTokenAsync(LoginDto loginDto);

        Task<TokenDto> CreateTokenByRefreshToken(string refreshToken);

        Task RevokeRefreshToken(string refreshToken);

       
    }
}
