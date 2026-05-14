using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClothingStoreWeb.Data;

namespace ClothingStoreWeb.Models
{
    public class Order
    {
        [Key]
        public int Order_Id { get; set; }

        [Required]
        public string User_Id { get; set; } = string.Empty;

        [Required]
        public DateTime Order_Date { get; set; }

        [Required]
        [StringLength(50)]
        public string Order_Status { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Order_TotalAmount { get; set; }

        public ApplicationUser? User { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; } = new List<OrderItem>();
    }
}