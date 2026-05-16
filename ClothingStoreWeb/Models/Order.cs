using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClothingStoreWeb.Data;

namespace ClothingStoreWeb.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }

        [Display(Name = "Пользователь")]
        [Required(ErrorMessage = "Выберите пользователя")]
        public string User_Id { get; set; } = string.Empty;

        [Display(Name = "Дата заказа")]
        [Required(ErrorMessage = "Укажите дату заказа")]
        public DateTime Order_Date { get; set; }

        [Display(Name = "Статус заказа")]
        [Required(ErrorMessage = "Выберите статус заказа")]
        [StringLength(50)]
        public string Order_Status { get; set; } = string.Empty;

        [Display(Name = "Сумма заказа")]
        [Required(ErrorMessage = "Введите сумму заказа")]
        [Range(0, double.MaxValue, ErrorMessage = "Сумма заказа не может быть отрицательной")]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Order_TotalAmount { get; set; }

        public ApplicationUser? User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}
