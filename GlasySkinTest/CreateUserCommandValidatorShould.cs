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
            yield return new[] { new RegisterUserDto
            {Login = string.Empty, Email = "kerwen.jumazew@gmail.com", Password = "MyPassword", PhoneNumber = "64635213452" } };
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
