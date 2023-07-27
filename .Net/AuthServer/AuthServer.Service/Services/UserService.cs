using AuthServer.Core.DTOs;
using AuthServer.Core.Entity;
using AuthServer.Core.Service;
using Microsoft.AspNetCore.Identity;
using SharedLibrary.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<AppUser> _userManager;

        public UserService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<Response<AppUserDto>> CreateUserAsync(CreateUserDto createUserDto)
        {
            var user = new AppUser { Email = createUserDto.Email, UserName = createUserDto.UserName };

            var result = await _userManager.CreateAsync(user,createUserDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(x => x.Description).ToList();

                return Response<AppUserDto>.Fail(400,new ErrorDto(errors, true));
            }

            return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);


        }

        public async Task<Response<AppUserDto>> GetUserByNameAsync(string userName)
        {
            var user = await _userManager.FindByNameAsync(userName);

            if (user==null)
            {
                return Response<AppUserDto>.Fail(404,"User Name not found",true);
            }

            return Response<AppUserDto>.Success(ObjectMapper.Mapper.Map<AppUserDto>(user), 200);
        }
    }
}
