    using BusinessModel.Model;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class StoreOrderDetailDTO
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }
    }

    public class StoreOrderDetailDTOReadOnly
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int GameID { get; set; }
        public string? GameName { get; set; }
        public string? GamePicture { get; set; }
        public decimal UnitPrice { get; set; }
        public DateTime CreatedAt { get; set; }

    }
}
