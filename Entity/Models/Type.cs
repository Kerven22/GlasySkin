using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entity.Models
{
    public class Type
    {
        [Key]
        [Column("TypeId")]
        public Guid TypeId { get; set; }

        public string Name { get; set; }

        [InverseProperty(nameof(Product.Type))]
        public ICollection<Product>? Products { get; set; }
    }
}
