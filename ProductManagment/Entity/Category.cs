using System.ComponentModel.DataAnnotations;

namespace ProductManagment.Entity
{
    public class Category
    {
        public Guid Id { get; set; }

        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        [Required(ErrorMessage = "Is required field")]
        public string Name { get; set; }
        [MaxLength(50, ErrorMessage = "Maximum length is 50 characters")]
        [Required(ErrorMessage = "Is required field")]
        public string Code { get; set; }
        [MaxLength]
        public string? Description { get; set; }
    }
}
