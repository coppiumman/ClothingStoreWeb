using System.ComponentModel.DataAnnotations;

namespace ClothingStoreWeb.Models
{
    public class Stock
    {
        [Key]
        public int Stock_Id { get; set; }

        [Required]
        public int Product_Id { get; set; }

        [Required]
        public int Size_Id { get; set; }

        [Required]
        public int Stock_Quantity { get; set; }

        public Product? Product { get; set; }

        public Size? Size { get; set; }
    }
}