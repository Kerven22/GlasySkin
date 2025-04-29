using AutoMapper;
using Entity.Models;
using FluentValidation;
using Repository.Contract.Abstractions;
using Service.Contract;
using Services.AuthenticationService;
using Shared.CreateDtos;
using Shared.LogInDto;
using Shared.ResponsiesDto;

namespace Services.UserService
{
    internal sealed class UserService(
        IRepositoryManager _repositoryManager,
        IJwtProvider _jwtProvider,
        IValidator<UserDto> _validator,
        IMapper _mapper) : IUserService
    {
        public async Task<UserDto> GetUser(string login, bool trackChanges)
        {
            var user = await _repositoryManager.User.GetUserByLoginAsync(login, trackChanges);            

            var userDto = _mapper.Map<UserDto>(user);

            return userDto;
        }

        public async Task<IEnumerable<UserResponse>> GetUsers(CancellationToken cancellationToken)
        {
            var usersEntity = _repositoryManager.User.GetAllUsers(cancellationToken);

            var userDto = usersEntity.Select(u => new UserResponse(u.UserId, u.Login, u.Email, u.PhoneNumber, u.BasketId));

            return userDto;
        }




        public async Task<string> Login(LogInDto logInDto)
        {
            var userDto = await GetUser(logInDto.Login, trackChanges: false);

            var result = PasswordHasher.Verify(logInDto.Password, userDto.Password);
            if (!result)
                throw new Exception("Faild to logIn");

            var token = _jwtProvider.GenerateToken(userDto);

            return token;
        }



        public async Task Register(UserDto user)
        {
            await _validator.ValidateAndThrowAsync(user);

            var hashPassword = PasswordHasher.Generate(user.Password);

            var userEntity = _mapper.Map<User>(user);
            
            var userId = GuidFactory.GuidFactory.Create();

            var basketId = await _repositoryManager.Basket.CreateBasket(); 

            userEntity.UserId = userId;
            userEntity.PasswordHash = hashPassword;
            userEntity.BasketId = basketId; 

            await _repositoryManager.User.Register(userEntity);
            await _repositoryManager.SaveAsync(); 
        }
    }
}
