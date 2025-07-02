using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class SystemTokenRefresh
    {
        public int Id { get; set; }
        public string UserID { get; set; }
        public string Token {  get; set; }  
        public string TokenRefresh {  get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } 
    }
}
