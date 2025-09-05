using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesInfoDiscount
    {
        [Key, Column(Order = 0)]
        public int GamesInfoId { get; set; }

        [ForeignKey("GamesInfoId")]
        public virtual GamesInfo GamesInfo { get; set; }

        [Key, Column(Order = 1)]
        public int GamesDiscountId { get; set; }

        [ForeignKey("GamesDiscountId")]
        public virtual GamesDiscount GamesDiscount { get; set; }
    }

}
