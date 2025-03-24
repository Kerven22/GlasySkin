using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class Type
    {
        public Guid TypeId { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(Product.Type))]
        public ICollection<Product>? Products { get; set; }
    }
}
