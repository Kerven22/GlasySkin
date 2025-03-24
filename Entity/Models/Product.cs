using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }

        public string? Name { get; set; }

        public decimal Cost { get; set; }

        public string? Review { get; set; }

        public int Quantity { get; set; } //количество товара в магазине

        public ICollection<Basket> Baskets { get; set; }

        [InverseProperty(nameof(Comment.Product))]
        public ICollection<Comment> Comments { get; set; }

        public Guid TypeId { get; set; }
        [ForeignKey(nameof(TypeId))]
        public Type Type { get; set; }
    }
}
