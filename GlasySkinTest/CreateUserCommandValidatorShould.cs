using FluentAssertions;
using Services.UserService;
using Shared.ValidatorCommands;

namespace GlasySkinTest
{
    public class CreateUserCommandValidatorShould
    {
        private readonly RegisterUserCommandValidator sut;

        public CreateUserCommandValidatorShould()
        {
            sut = new RegisterUserCommandValidator();
        }

        [Fact]
        public void ReturnSuccess_WhenCommandValid()
        {
            var actual = sut.Validate(new RegisterUserDto()
            { Login = "Kerim91", Email = "Kerimjk91", PhoneNumber = "166412555", Password = "MyPassowrd" });

            actual.IsValid.Should().Be(true);
        }


        public static IEnumerable<object[]> GetInvalidRegisterUserDto()
        {
            var userRegister = new RegisterUserDto()
            { Login = "Martin Albinos", Email = "kerwen.jumazew@gmail.com", Password = "MyPassword", PhoneNumber = "64635213452" };


            yield return new object[] { userRegister with { Login = "" } };
            yield return new object[] { userRegister with { Email = string.Empty } };
            yield return new object[] { userRegister with { Password = "dkdk" } };
            yield return new object[] { userRegister with { PhoneNumber = "" } }; 
        }

        [Theory]
        [MemberData(nameof(GetInvalidRegisterUserDto))]
        public void ReturnFialer_WhenUserCommandIsInvalid(RegisterUserDto registerUserDto)
        {
            var actual = sut.Validate(registerUserDto);

            actual.IsValid.Should().Be(false);
        }
    }
}
