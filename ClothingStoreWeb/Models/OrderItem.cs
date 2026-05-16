using DocumentFormat.OpenXml.Drawing.Charts;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreWeb.Models
{
    public class OrderItem
    {
        [Key]
        public int OrderItem_Id { get; set; }

        [Display(Name = "Заказ")]
        [Required(ErrorMessage = "Выберите заказ")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите заказ")]
        public int Order_Id { get; set; }

        [Display(Name = "Товар")]
        [Required(ErrorMessage = "Выберите товар")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите товар")]
        public int Product_Id { get; set; }

        [Display(Name = "Размер")]
        [Required(ErrorMessage = "Выберите размер")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите размер")]
        public int Size_Id { get; set; }

        [Display(Name = "Количество")]
        [Required(ErrorMessage = "Введите количество")]
        [Range(1, int.MaxValue, ErrorMessage = "Количество должно быть больше 0")]
        public int OrderItem_Quantity { get; set; }

        [Display(Name = "Цена позиции")]
        [Required(ErrorMessage = "Введите цену позиции")]
        [Range(0, double.MaxValue, ErrorMessage = "Цена позиции не может быть отрицательной")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal OrderItem_Price { get; set; }

        public Order? Order { get; set; }

        public Product? Product { get; set; }

        public Size? Size { get; set; }
    }
}
