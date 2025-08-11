namespace DataAccess.DTOs
{
    public class DepositWithdrawRequestDTO
    {
        public decimal Amount { get; set; }
        // "DEPOSIT" hoặc "WITHDRAW"
        public string Type { get; set; } = "DEPOSIT";
        public string? Note { get; set; }
    }

    public class DepositWithdrawApproveDTO
    {
        public int Id { get; set; }
        // "Approved" hoặc "Rejected"
        public string Status { get; set; } = "Approved";
        public string? Note { get; set; }
    }

    public class WalletSummaryDTO
    {
        public decimal Balance { get; set; }
        public DateTime UpdatedAt { get; set; }
    }

    public class DepositWithdrawListItemDTO
    {
        public int Id { get; set; }
        public string Type { get; set; } = null!;
        public string Status { get; set; } = null!;
        public decimal Amount { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? ApprovedAt { get; set; }
        public string? ApprovedBy { get; set; }
        public string? Note { get; set; }
    }
}
