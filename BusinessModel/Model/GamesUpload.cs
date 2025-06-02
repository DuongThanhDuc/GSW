using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesUpload
    {
        public int ID { get; set; }

        public string DeveloperID { get; set; }

        public int GameID { get; set; }
        public GamesInfo Game { get; set; }

        public string GameVersion { get; set; }
        public string Notes { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;
    }
}
