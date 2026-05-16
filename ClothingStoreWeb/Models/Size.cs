using System.ComponentModel.DataAnnotations;

namespace ClothingStoreWeb.Models
{
    public class Size
    {
        [Key]
        public int Size_Id { get; set; }

        [Display(Name = "Размер")]
        [Required(ErrorMessage = "Введите размер")]
        [StringLength(20, ErrorMessage = "Размер не должен превышать 20 символов")]
        public string Size_Name { get; set; } = string.Empty;

        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
