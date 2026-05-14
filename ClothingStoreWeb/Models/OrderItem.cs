using DocumentFormat.OpenXml.Drawing.Charts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreWeb.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItem_Id { get; set; }

        [Required]
        public int Order_Id { get; set; }

        [Required]
        public int Product_Id { get; set; }

        [Required]
        public int Size_Id { get; set; }

        [Required]
        public int OrderItem_Quantity { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderItem_Price { get; set; }

        public Order? Order { get; set; }

        public Product? Product { get; set; }

        public Size? Size { get; set; }
    }
}