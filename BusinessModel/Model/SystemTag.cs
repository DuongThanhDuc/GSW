using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class SystemTag
    {
        public int ID { get; set; }

        [Required]
        [StringLength(100)]  
        public string TagName { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [StringLength(50)]  
        public string CreatedBy { get; set; }
    }

}
