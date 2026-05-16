using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClothingStoreWeb.Data;

namespace ClothingStoreWeb.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }

        [Display(Name = "Пользователь")]
        [Required(ErrorMessage = "Выберите пользователя")]
        public string User_Id { get; set; } = string.Empty;

        [Display(Name = "Должность")]
        [Required(ErrorMessage = "Выберите должность")]
        [StringLength(100, ErrorMessage = "Должность не должна превышать 100 символов")]
        public string Employee_Position { get; set; } = string.Empty;

        [Display(Name = "Зарплата")]
        [Required(ErrorMessage = "Введите зарплату")]
        [Range(0, double.MaxValue, ErrorMessage = "Зарплата не может быть отрицательной")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Employee_Salary { get; set; }

        [Display(Name = "Дата приёма на работу")]
        [Required(ErrorMessage = "Укажите дату приёма на работу")]
        public DateTime Employee_HireDate { get; set; }

        public ApplicationUser? User { get; set; }
    }
}
