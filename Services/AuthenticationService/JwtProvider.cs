using Microsoft.IdentityModel.Tokens;
using Shared.CreateDtos;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Services.AuthenticationService
{
    
    public class JwtProvider:IJwtProvider
    {

        public string GenerateToken(UserDto userDto)
        {
            Claim[] claims = [new("Login", userDto.Login), new(ClaimTypes.Role, "Admin")];

            var signingCredentials = new SigningCredentials(
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AuthOption.SecretKey)), SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                claims: claims,
                signingCredentials: signingCredentials,
                expires: DateTime.UtcNow.AddHours(AuthOption.ExpiresHours),
                audience: AuthOption.Audience,
                issuer: AuthOption.Issure);

            var tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenValue;
        }

    }
}
