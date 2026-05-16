using System.ComponentModel.DataAnnotations;

namespace ClothingStoreWeb.Models
{
    public class Stock
    {
        [Key]
        public int Stock_Id { get; set; }

        [Display(Name = "Товар")]
        [Required(ErrorMessage = "Выберите товар")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите товар")]
        public int Product_Id { get; set; }

        [Display(Name = "Размер")]
        [Required(ErrorMessage = "Выберите размер")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите размер")]
        public int Size_Id { get; set; }

        [Display(Name = "Количество на складе")]
        [Required(ErrorMessage = "Введите количество на складе")]
        [Range(0, int.MaxValue, ErrorMessage = "Количество на складе не может быть отрицательным")]
        public int Stock_Quantity { get; set; }

        public Product? Product { get; set; }

        public Size? Size { get; set; }
    }
}
