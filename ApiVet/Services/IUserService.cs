using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiVet.Dtos;

namespace ApiVet.Services
{
    public interface IUserService
    {
        Task<string> RegisterAsync(RegisterDto model);
        Task<DataUserDto> GetTokenAsync(LoginDto model);
        Task<string> AddRoleAsync(AddRolDto model);
        Task<DataUserDto> RefreshTokenAsync(string refreshToken);
    }
}