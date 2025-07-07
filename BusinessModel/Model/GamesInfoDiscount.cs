using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesInfoDiscount
    {
        public int GamesInfoId { get; set; }
        public GamesInfo GamesInfo { get; set; }

        public int GamesDiscountId { get; set; }
        public GamesDiscount GamesDiscount { get; set; }
    }
}
