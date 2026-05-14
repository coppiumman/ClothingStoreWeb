using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreWeb.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Category_Name { get; set; } = string.Empty;

        [StringLength(500)]
        public string? Category_Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}