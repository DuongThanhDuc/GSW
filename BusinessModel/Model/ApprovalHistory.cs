using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        [Required]
        public string ChangedByUserId { get; set; }     
        public DateTime ChangedAt { get; set; }
        public string Note { get; set; }          
    }
}
