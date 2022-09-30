using ProductManagment.Entity;

namespace ProductManagment.Model
{
    public class CreatePackageProductRequest
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public Package Package { get; set; }
        public Guid ProductId { get; set; }
        public Product Product { get; set; }
    }
}
