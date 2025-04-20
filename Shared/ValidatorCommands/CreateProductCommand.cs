namespace Services.ProductService
{
    public class CreateProductCommand
    {
        public Guid TypeId { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public int Quantity { get; set; }
        public string Review { get; set; }
    }
}
