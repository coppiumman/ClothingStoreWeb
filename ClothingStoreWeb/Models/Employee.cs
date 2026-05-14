using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ClothingStoreWeb.Data;

namespace ClothingStoreWeb.Models
{
    public class Employee
    {
        [Key]
        public int Employee_Id { get; set; }

        [Required]
        public string User_Id { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Employee_Position { get; set; } = string.Empty;

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Employee_Salary { get; set; }

        [Required]
        public DateTime Employee_HireDate { get; set; }

        public ApplicationUser? User { get; set; }
    }
}