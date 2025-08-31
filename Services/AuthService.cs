using AdvFullstack_Labb1.Models.DTOs;
using AdvFullstack_Labb1.Models.Entities;
using AdvFullstack_Labb1.Repositories.IRepositories;
using AdvFullstack_Labb1.Services.IServices;
using AdvFullstack_Labb1.Services.Shared;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AdvFullstack_Labb1.Services
{
    public class AuthService : IAuthService
    {
        private readonly IAdminRepository _adminRepo;
        private readonly IConfiguration _config;
        private readonly PasswordHasher _hasher;

        public AuthService(IAdminRepository adminRepo, IConfiguration config, PasswordHasher hasher)
        {
            _adminRepo = adminRepo;
            _config = config;
            _hasher = hasher;
        }

        public async Task<LoginResponseDto> LoginAsync(string username, string password)
        {
            var admin = await _adminRepo.GetByUsernameAsync(username);

            if (admin == null || !_hasher.VerifyPassword(password, admin.PasswordHash))
                return null;

            var jwt = new LoginResponseDto()
            {
                Jwt = GenerateJwt(admin)
            };

            return jwt;
        }

        private string GenerateJwt(Admin admin)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, admin.Username)
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: credentials
                );

            return new JwtSecurityTokenHandler().WriteToken(token);


        }
    }
}
