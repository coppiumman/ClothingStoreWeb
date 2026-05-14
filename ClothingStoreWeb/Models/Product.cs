using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreWeb.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Required]
        public int Category_Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Product_Name { get; set; } = string.Empty;

        public string? Product_Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Product_Price { get; set; }

        [StringLength(100)]
        public string? Product_Coloring { get; set; }

        [StringLength(500)]
        public string? Product_ImagePath { get; set; }

        public Category? Category { get; set; }

        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}