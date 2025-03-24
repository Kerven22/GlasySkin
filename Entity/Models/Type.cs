namespace Entity.Models
{
    public class Type
    {
        public Guid TypeId { get; set; }
        public string Name { get; set; }
        public ICollection<Product>? Products { get; set; }
    }
}
