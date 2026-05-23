using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClothingStoreWeb.Models
{
    public class Category
    {
        [Key]
        public int Category_Id { get; set; }

        [Display(Name = "Название категории")]
        [Required(ErrorMessage = "Введите название категории")]
        [StringLength(100, ErrorMessage = "Название категории не должно превышать 100 символов")]
        public string Category_Name { get; set; } = string.Empty;

        [Display(Name = "Описание категории")]
        [StringLength(500, ErrorMessage = "Описание категории не должно превышать 500 символов")]
        public string? Category_Description { get; set; }

        [Display(Name = "Порядок отображения")]
        public int Category_DisplayOrder { get; set; }
        public bool Category_IsHidden { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
