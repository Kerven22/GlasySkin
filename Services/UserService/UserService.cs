using Repository.Contract.Abstractions;
using Service.Contract;
using Services.AuthenticationService;
using Shared.CreateDtos;
using Shared.LogInDto;
using Shared.ResponsiesDto;
using Shared.ValidatorCommands;

namespace Services.UserService
{
    internal sealed class UserService(IRepositoryManager _repositoryManager, IJwtProvider _jwtProvider) : IUserService
    {
        public async Task<UserDto> GetUser(string login, bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUserByLoginAsync(login, trackChanges);

            var userDto = new UserDto(user.Login, user.PasswordHash, user.Email, user.PhoneNumber);

            return userDto;             
        }

        public async Task<IEnumerable<UserResponse>> GetUsers(CancellationToken cancellationToken)
        {
            var usersEntity = _repositoryManager.User.GetAllUsers(cancellationToken);

            var userDto = usersEntity.Select(u => new UserResponse(u.UserId, u.Login, u.Email, u.PhoneNumber));

            return userDto; 
        }




        public async Task<string> Login(LogInDto logInDto)
        {
            var userDto = await GetUser(logInDto.Login, trackChanges:false);

            var result = PasswordHasher.Verify(logInDto.Password, userDto.Password);
            if (!result)
                throw new Exception("Faild to logIn");

            var token = _jwtProvider.GenerateToken(userDto);

            return token; 
        }



        public async Task Register(RegisterUserDto userCommand)
        {
            var hashPassword = PasswordHasher.Generate(userCommand.Password);

            await _repositoryManager.User.Register(userCommand.Login, hashPassword, userCommand.Email, userCommand.PhoneNumber); 
        }
    }
}
