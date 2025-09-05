using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusinessModel.Model
{
    public class DepositWithdrawTransaction
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string UserId { get; set; } = null!;

        [Precision(18, 2)]
        [Range(0.01, 999999999)]
        public decimal Amount { get; set; }

        [Required, MaxLength(10)]  
        public string Type { get; set; } = null!;

        [Required, MaxLength(20)]  
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? ApprovedAt { get; set; }

        [StringLength(512)]  
        public string? ApprovedBy { get; set; }

        [MaxLength(512)]  
        public string? Note { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }

}
