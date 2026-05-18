using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreWeb.Models
{
    public class Product
    {
        [Key]
        public int Product_Id { get; set; }

        [Display(Name = "Категория")]
        [Required(ErrorMessage = "Выберите категорию")]
        [Range(1, int.MaxValue, ErrorMessage = "Выберите категорию")]
        public int Category_Id { get; set; }

        [Display(Name = "Название товара")]
        [Required(ErrorMessage = "Введите название товара")]
        [StringLength(150, ErrorMessage = "Название товара не должно превышать 150 символов")]
        public string Product_Name { get; set; } = string.Empty;

        [Display(Name = "Описание товара")]
        [StringLength(500, ErrorMessage = "Описание товара не должно превышать 500 символов")]
        public string? Product_Description { get; set; }

        [Display(Name = "Цена")]
        [Required(ErrorMessage = "Введите цену")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Цена должна быть больше 0")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Product_Price { get; set; }

        [Display(Name = "Цвет")]
        [StringLength(100, ErrorMessage = "Название цвета не должно превышать 100 символов")]
        public string? Product_Coloring { get; set; }

        [Display(Name = "Порядок отображения")]
        public int Product_DisplayOrder { get; set; }

        [Display(Name = "Путь к изображению")]
        [StringLength(500, ErrorMessage = "Путь к изображению не должен превышать 500 символов")]
        public string? Product_ImagePath { get; set; }

        [StringLength(500, ErrorMessage = "Путь к изображению не должен превышать 500 символов")]
        public string? Product_ImagePath2 { get; set; }

        [StringLength(500, ErrorMessage = "Путь к изображению не должен превышать 500 символов")]
        public string? Product_ImagePath3 { get; set; }

        [StringLength(500, ErrorMessage = "Путь к изображению не должен превышать 500 символов")]
        public string? Product_ImagePath4 { get; set; }

        public Category? Category { get; set; }

        public ICollection<Stock> Stocks { get; set; } = new List<Stock>();

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
