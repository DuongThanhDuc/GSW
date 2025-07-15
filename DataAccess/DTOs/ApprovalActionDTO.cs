using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class ApprovalActionDTO
    {
        public string Status { get; set; } // "Approved", "Rejected", etc.
        public string Note { get; set; }
    }
}
