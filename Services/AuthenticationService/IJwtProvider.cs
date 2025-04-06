using Shared.CreateDtos;

namespace Services.AuthenticationService
{
    public interface IJwtProvider
    {
        string GenerateToken(UserDto userDto);
    }
}
