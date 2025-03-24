namespace Entity.Models
{
    public class Basket
    {
        public Guid BasketId { get; set; }

        public Guid UserId { get; set; }

        public User User { get; set; }

        public ICollection<Product> Products { get; set;  }
    }
}
