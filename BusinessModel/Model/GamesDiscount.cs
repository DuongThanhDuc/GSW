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
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string Code { get; set; }

        [StringLength(512)]  
        public string Description { get; set; }

        [Range(0, 100)]  
        public decimal Value { get; set; }

        public bool IsPercent { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        public virtual ICollection<GamesInfoDiscount> GamesInfoDiscounts { get; set; }
    }

}
