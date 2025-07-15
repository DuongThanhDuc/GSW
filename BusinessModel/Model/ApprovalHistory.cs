using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class ApprovalHistory
    {
        public int Id { get; set; }
        public string EntityType { get; set; }    // "Game", "Refund", ...
        public int EntityId { get; set; }         // GamesInfo.Id hoặc StoreRefundRequest.ID
        public string Status { get; set; }
        public string ChangedBy { get; set; }     // UserName hoặc UserId của Admin thực hiện
        public DateTime ChangedAt { get; set; }
        public string Note { get; set; }          // Ghi chú duyệt/từ chối
    }
}
