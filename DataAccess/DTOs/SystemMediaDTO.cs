using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class SystemMediaDTO
    {
        public int Id { get; set; }
        public string MediaURL { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
