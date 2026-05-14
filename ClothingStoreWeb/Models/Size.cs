using System.ComponentModel.DataAnnotations;

namespace ClothingStoreWeb.Models
{
    public class Size
    {
        [Key]
        public int Size_Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Size_Name { get; set; } = string.Empty;

        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}