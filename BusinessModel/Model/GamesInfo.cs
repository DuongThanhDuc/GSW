using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesInfo
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Genre { get; set; }

        public string DeveloperId { get; set; }

        public DateTime? ReleaseDate { get; set; }
        public int InstallerFileID { get; set; }
        public int CoverImageID { get; set; }
        public string Status { get; set; } = "Pending";

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public string CreatedBy { get; set; }

        public ICollection<GamesCategory> GameCategories { get; set; }
        public ICollection<GamesTag> GameTags { get; set; }
        public ICollection<GamesReview> Reviews { get; set; }
    }
}
