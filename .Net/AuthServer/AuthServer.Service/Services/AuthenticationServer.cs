using AuthServer.Core.Configuration;
using AuthServer.Core.DTOs;
using AuthServer.Core.Entity;
using AuthServer.Core.Repository;
using AuthServer.Core.Service;
using AuthServer.Core.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service.Services
{
    public class AuthenticationServer : IAuthenticationService
    {
        private readonly List<Client> _clients;
        private readonly ITokenService _tokenService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGenericRepository<UserRefreshToken> _repository;

        public AuthenticationServer(IOptions<List<Client>> optionsClient, ITokenService tokenService, UserManager<AppUser> userManager, IUnitOfWork unitOfWork, IGenericRepository<UserRefreshToken> repository)
        {
            _clients = optionsClient.Value;
            _tokenService = tokenService;
            _userManager = userManager;
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<Response<TokenDto>> CreateTokenAsync(LoginDto loginDto)
        {
            if (loginDto==null)
            {
                throw new ArgumentNullException(nameof(loginDto));
            }

            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user==null)
            {
                return Response<TokenDto>.Fail(400, "Email or Password is wrong",true);
            }

            if ( !await _userManager.CheckPasswordAsync(user,loginDto.Password) )
            {
                return Response<TokenDto>.Fail(400, "Email or Password is wrong", true);

            }

            var token = _tokenService.CreateToken(user);

            var userRefreshToken = await _repository.Where(x => x.UserId == user.Id).SingleOrDefaultAsync();

            if (userRefreshToken==null)
            {
                await _repository.AddAsync(new UserRefreshToken { UserId = user.Id, Code = token.RefreshToken, Expiration = token.RefreshTokenExpiration });
            }
            else
            {
                userRefreshToken.Code = token.RefreshToken;
                userRefreshToken.Expiration = token.RefreshTokenExpiration;
            }

            await _unitOfWork.CommitAsync();

            return Response<TokenDto>.Success(token, 200);

        }

        public Response<ClientTokenDto> CreateTokenByClient(ClientLoginDto loginDto)
        {
            var client = _clients.SingleOrDefault(x => x.Id == loginDto.ClientId && x.Secret == loginDto.ClientSecret);

            if (client==null)
            {
                return Response<ClientTokenDto>.Fail(404, "Client Id or Client Secret not found", true);
            }

            var token = _tokenService.CreateTokenByClient(client);

            return Response<ClientTokenDto>.Success(token, 200);
        }

        public async Task<Response<TokenDto>> CreateTokenByRefreshTokenAsync(string refreshToken)
        {
            var existRefreshToken = await _repository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken==null)
            {
                return Response<TokenDto>.Fail(404, "Refresh token not found", true);
            }

            var user = await _userManager.FindByIdAsync(existRefreshToken.UserId);

            if (user==null)
            {
                return Response<TokenDto>.Fail(404, "User Id not found", true);

            }

            var tokenDto = _tokenService.CreateToken(user);

            existRefreshToken.Code = tokenDto.RefreshToken;
            existRefreshToken.Expiration = tokenDto.RefreshTokenExpiration;

            await _unitOfWork.CommitAsync();

           return    Response<TokenDto>.Success(tokenDto, 200);

        }

        public async Task<Response<NoDataDto>> RevokeRefreshToken(string refreshToken)
        {
            var existRefreshToken = await _repository.Where(x => x.Code == refreshToken).SingleOrDefaultAsync();

            if (existRefreshToken==null)
            {
                return Response<NoDataDto>.Fail(404, "Refresh token not found", true);

            }

            _repository.Delete(existRefreshToken);
            await _unitOfWork.CommitAsync();

            return Response<NoDataDto>.Success(200);
        }
    }
}
