using ProductManagment.Entity;

namespace ProductManagment.Model
{
    public class PackageProductModel
    {
        public Guid Id { get; set; }
        public Guid PackageId { get; set; }
        public Guid ProductId { get; set; }
    }
}
