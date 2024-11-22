using System.ComponentModel.DataAnnotations;

namespace ImageUploadAspNetCore.Models
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public float? Price { get; set; }
        [Required]
        public IFormFile photo { get; set; }
    }
}
