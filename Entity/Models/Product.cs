namespace Entity.Models
{
    public class Product
    {
        public Guid ProductId { get; set; }
        public string? Name { get; set; }
        public decimal Cost { get; set; }
        public string? Review { get; set; }
        public int Count { get; set; }
    }
}
