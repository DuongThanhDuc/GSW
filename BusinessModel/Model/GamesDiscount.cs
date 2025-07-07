using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesDiscount
    {
        public int Id { get; set; }

       
        public string Code { get; set; }

    
        public string Description { get; set; }

     
        public decimal Value { get; set; }

        public bool IsPercent { get; set; }

      
        public DateTime StartDate { get; set; }

        
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
        public virtual ICollection<GamesInfoDiscount> GamesInfoDiscounts { get; set; }
    }
}
