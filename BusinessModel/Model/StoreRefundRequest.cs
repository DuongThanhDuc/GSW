using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreRefundRequest
    {
        public int ID { get; set; }

        [Required]
        public int OrderID { get; set; }

        [ForeignKey("OrderID")]
        public StoreOrder Order { get; set; }

        [Required]
        [StringLength(50)]  
        public string UserID { get; set; }

        [StringLength(512)]  
        public string Reason { get; set; }

        [StringLength(20)]  
        public string Status { get; set; } = "PENDING";

        public DateTime RequestDate { get; set; } = DateTime.Now;
    }

}
