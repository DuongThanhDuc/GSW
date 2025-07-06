using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DTOs
{
    public class GamesInfoDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }
        public string DeveloperId { get; set; }
        public string InstallerFilePath { get; set; }
        public string CoverImagePath { get; set; }
        public string Status { get; set; }
        public string CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public List<GamesReviewDTO> Reviews { get; set; }
        public List<GamesMediaDTO> Media { get; set; }

    }
}
