using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreThreadUpvoteHistory
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public int ThreadID { get; set; }
        public StoreThread StoreThread { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
