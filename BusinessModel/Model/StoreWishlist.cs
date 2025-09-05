using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class StoreWishlist
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]  
        public string UserId { get; set; }

        [Required]
        public int GameId { get; set; }

        [ForeignKey("GameId")]
        public GamesInfo GamesInfo { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

}
