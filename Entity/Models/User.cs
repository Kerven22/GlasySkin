using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class User
    {
        [Key]
        [Column("UserId")]
        public Guid UserId { get; set; }

        public string Login { get; set; }

        public string PasswordHash { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public Guid BasketId { get; set; }
        [ForeignKey(nameof(BasketId))]
        public Basket? Basket { get; set; }

        [InverseProperty(nameof(Comment.User))]
        public ICollection<Comment> Comments { get; set; }

    }
}
