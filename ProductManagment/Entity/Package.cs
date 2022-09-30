using System.ComponentModel.DataAnnotations;

namespace ProductManagment.Entity
{
    public class Package
    {
        public Package()
        {
            PackageProducts = new List<PackageProduct>();
        }

        public Guid Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        [Required(ErrorMessage = "Is required field")]
        public string Name { get; set; }  
        public decimal Price { get; set; }
        public List<PackageProduct> PackageProducts { get; set; }
        [MaxLength]
        public string? Description { get; set; }
        

    }
}
