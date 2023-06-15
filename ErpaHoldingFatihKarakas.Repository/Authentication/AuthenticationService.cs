using ErpaHoldingFatihKarakas.Domain.Authentication;
using ErpaHoldingFatihKarakas.Domain.Authentication.Dto;
using ErpaHoldingFatihKarakas.Domain.Repositories;
using ErpaHoldingFatihKarakas.Domain.Token;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpaHoldingFatihKarakas.Repository.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
       
        private readonly ITokenService _tokenService;
        private readonly UserManager<User> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserRefreshTokenRepository _userRefreshTokenRepository;


        public AuthenticationService(ITokenService tokenService, UserManager<User> userManager, IUnitOfWork unitOfWork, IUserRefreshTokenRepository userRefreshTokenRepository)
        {


            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _userRefreshTokenRepository = userRefreshTokenRepository;
        }

        public async Task<TokenDto> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto == null) throw new ArgumentNullException(nameof(loginDto));


            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user == null) { throw new Exception("Bulunamadı"); }

            if (!await _userManager.CheckPasswordAsync(user, loginDto.Password))
            {
                throw new Exception("Email Veya Şifre Yanlış");
            }
            var token = _tokenService.CreateToken(user);

            var userRefreshToken = await _userRefreshTokenRepository.GetAll().Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken == null)
            {
               await _userRefreshTokenRepository.CreateAsync
                    (new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
                await _userRefreshTokenRepository.UpdateAsync(userRefreshToken);
            }

            await _unitOfWork.SaveChangesAsync();

            return token;
        }

   

        public async Task<TokenDto> CreateTokenByRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenRepository.GetAll().Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken == null)
            {
                throw new Exception("Bulunamadı");
            }

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId.ToString());

            if (user == null)
            {
                throw new Exception("Bulunamadı");
            }

            var tokenDto = _tokenService.CreateToken(user);

            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.SaveChangesAsync();

            return tokenDto;
        }

        public async Task RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _userRefreshTokenRepository.GetAll().Where(x => x.Code == refreshToken).SingleOrDefaultAsync();
            if (existRefreshToken == null)
            {
                throw new Exception("Bulunamadı");

            }

           await _userRefreshTokenRepository.DeleteAsync(existRefreshToken);

            await _unitOfWork.SaveChangesAsync();

       
        }
    }
}
