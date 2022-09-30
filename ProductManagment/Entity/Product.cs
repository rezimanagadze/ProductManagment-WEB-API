using System.ComponentModel.DataAnnotations;

namespace ProductManagment.Entity
{
    public class Product
    {
        public Guid Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        [Required(ErrorMessage = "Is required field")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Is required field")]
        public decimal Price { get; set; }
        public Category Category { get; set; }
        [MaxLength]
        public string? Description { get; set; }

    }
}