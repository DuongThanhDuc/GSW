using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class TopSellingGameRequestDTO
    {
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public int TopN { get; set; } = 10;
        public string Genre { get; set; }        // Filter thể loại
        public string DeveloperId { get; set; }  // Filter developer
        public string Status { get; set; }       // Filter trạng thái game
        public int Page { get; set; } = 1;       // Phân trang (page index, bắt đầu từ 1)
        public int PageSize { get; set; } = 10;  // Số dòng/trang
    }

}
