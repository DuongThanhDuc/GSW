using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class SystemMedia
    {
        public int Id { get; set; }

        [Required]
        [StringLength(512)] 
        public string MediaURL { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
