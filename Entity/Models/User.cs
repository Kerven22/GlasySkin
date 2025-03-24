using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class User
    {
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        [InverseProperty(nameof(Comment.User))]
        public ICollection<Comment> Comments { get; set; }

    }
}
