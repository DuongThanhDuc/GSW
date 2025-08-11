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
        public string UserId { get; set; } = null!;

        [Precision(18, 2)]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Amount { get; set; }

        // "DEPOSIT" | "WITHDRAW"
        [Required, MaxLength(10)]
        public string Type { get; set; } = null!;

        // "Pending" | "Approved" | "Rejected"
        [Required, MaxLength(20)]
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime? ApprovedAt { get; set; }

        // Admin duyệt
        public string? ApprovedBy { get; set; }

        [MaxLength(1000)]
        public string? Note { get; set; }

        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}
