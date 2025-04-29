using Shared.CreateDtos;

namespace Shared.ValidatorCommands
{
    public record RegisterUserDto
    {
        public string Login { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
