using Shared.CreateDtos;
using Shared.LogInDto;
using Shared.ResponsiesDto;
using Shared.ValidatorCommands;

namespace Service.Contract
{
    public interface IUserService
    {
        Task Register(UserDto userCommand);

        Task<UserDto> GetUser(string login, bool trakChanges); 
        
        Task<string> Login(LogInDto logInDto);

        Task<IEnumerable<UserResponse>> GetUsers(CancellationToken cancellationToken); 
    }
}
