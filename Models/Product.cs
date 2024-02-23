using System.ComponentModel.DataAnnotations;

namespace RetailInvetorySystem.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int? Quantity { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public double? Price { get; set; }

        public Category? Category { get; set; }
    }
}
