using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class DepositWithdrawRequestDTO
    {
        public decimal Amount { get; set; }
        public string Type { get; set; } // "DEPOSIT" hoặc "WITHDRAW"
        public string Note { get; set; }
    }

    public class DepositWithdrawApproveDTO
    {
        public int Id { get; set; }
        public string Status { get; set; } // "Approved" hoặc "Rejected"
        public string Note { get; set; }
    }

}
