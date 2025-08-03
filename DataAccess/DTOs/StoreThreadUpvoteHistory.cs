using BusinessModel.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    internal class StoreThreadUpvoteHistory
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int ThreadID { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
