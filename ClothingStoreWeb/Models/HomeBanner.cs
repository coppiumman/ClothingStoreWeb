using System.ComponentModel.DataAnnotations;

namespace ClothingStoreWeb.Models
{
    public class HomeBanner
    {
        [Key]
        public int HomeBanner_Id { get; set; }

        [Required(ErrorMessage = "Укажите тип баннера")]
        [StringLength(30)]
        public string HomeBanner_Type { get; set; } = "Hero";

        [StringLength(100)]
        public string? HomeBanner_Label { get; set; }

        [Required(ErrorMessage = "Укажите заголовок баннера")]
        [StringLength(150, ErrorMessage = "Заголовок не должен превышать 150 символов")]
        public string HomeBanner_Title { get; set; } = string.Empty;

        [StringLength(500, ErrorMessage = "Описание не должно превышать 500 символов")]
        public string? HomeBanner_Description { get; set; }

        [StringLength(80)]
        public string? HomeBanner_ButtonText { get; set; }

        [StringLength(300)]
        public string? HomeBanner_ButtonUrl { get; set; }

        [StringLength(500)]
        public string? HomeBanner_ImagePath { get; set; }

        public int HomeBanner_DisplayOrder { get; set; } = 1;

        public bool HomeBanner_IsHidden { get; set; }

        public DateTime HomeBanner_CreatedAt { get; set; } = DateTime.Now;

        public DateTime? HomeBanner_UpdatedAt { get; set; }
    }
}