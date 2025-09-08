using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModel.Model
{
    public class GamesInfo
    {
        [Key]
        public int Id { get; set; }    

        [Required]
        [MaxLength(250)]
        public string Title { get; set; }
        [MaxLength(512)]
        public string Description { get; set; }
        public decimal Price { get; set; }
        [MaxLength(50)]
        public string Genre { get; set; }
        [MaxLength(450)]
        public string DeveloperId { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public string InstallerFilePath { get; set; }
        public string CoverImagePath { get; set; }
        [MaxLength(20)]
        public string Status { get; set; } = "Pending";
        public bool IsActive { get; set; } = true;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        [MaxLength(450)]
        public string CreatedBy { get; set; }

        public ICollection<GamesCategory> GameCategories { get; set; }
        public ICollection<GamesTag> GameTags { get; set; }
        public ICollection<GamesReview> Reviews { get; set; }
        public ICollection<GamesDiscount> Discounts { get; set; }
        public ICollection<GamesMedia> Media { get; set; }
        public virtual ICollection<GamesInfoDiscount> GamesInfoDiscounts { get; set; }

        [NotMapped]
        public GamesDiscount ActiveDiscount { get; set; }
    }
}
