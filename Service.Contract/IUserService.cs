using Shared.CreateDtos;
using Shared.LogInDto;
using Shared.ValidatorCommands;

namespace Service.Contract
{
    public interface IUserService
    {
        Task Register(RegisgerUserDto userCommand);

        Task<UserDto> GetUser(string login, bool trakChanges); 
        
        Task<string> Login(LogInDto logInDto); 
    }
}
