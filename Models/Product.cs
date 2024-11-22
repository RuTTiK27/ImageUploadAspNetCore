using System.ComponentModel.DataAnnotations;

namespace ImageUploadAspNetCore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public double? Price { get; set; }
        [Required]
        public string ImagePath { get; set; }
    }
}
