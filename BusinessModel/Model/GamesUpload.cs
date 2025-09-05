using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesUpload
    {
        public int ID { get; set; }

        [Required]
        public string DeveloperID { get; set; }

        [Required]
        public int GameID { get; set; }

        [ForeignKey("GameID")]
        public GamesInfo Game { get; set; }

        [StringLength(50)]  
        public string GameVersion { get; set; }

        [StringLength(512)]  
        public string Notes { get; set; }

        public DateTime UploadDate { get; set; } = DateTime.Now;
    }

}
