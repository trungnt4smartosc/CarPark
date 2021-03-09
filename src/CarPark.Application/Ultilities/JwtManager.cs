using CarPark.Application.ApplicationUsers;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarPark.Application.Ultilities
{
    public interface IJwtManager
    {
        string GenerateToken(ApplicationUserDto userInfo);
    }

    public class JwtManager : IJwtManager
    {
        private IConfiguration _config;

        public JwtManager(IConfiguration config)
        {
            _config = config;
        }

        public string GenerateToken(ApplicationUserDto userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                _config["Jwt:Issuer"],
                _config["Jwt:Issuer"],
                null,
                expires: DateTime.Now.AddMinutes(120),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
