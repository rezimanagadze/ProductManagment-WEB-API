using ProductManagment.Entity;

namespace ProductManagment.Model
{
    public class CreateProductRequest
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
    }
}
