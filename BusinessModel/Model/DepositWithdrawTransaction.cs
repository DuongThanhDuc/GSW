using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class DepositWithdrawTransaction
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } // "DEPOSIT" hoặc "WITHDRAW"
        public string Status { get; set; } // "Pending", "Approved", "Rejected"
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string? ApprovedBy { get; set; } // Admin duyệt
        public string Note { get; set; }

        [ForeignKey("UserId")]
        public IdentityUser User { get; set; }
    }

}
