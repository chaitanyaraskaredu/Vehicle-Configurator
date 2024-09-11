using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetProject.Models
{
    [Table("models")]
    public class Model
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [Column("mod_name")]
        public string ModName { get; set; } = null!;

        [Required]
        [Column("price")]
        public int Price { get; set; }

        [Required]
        [Column("image_path")]
        public string ImagePath { get; set; } = null!;

        [Required]
        [Column("min_qty")]
        public int MinQty { get; set; }

        [Column("safety_rating")]
        public int? SafetyRating { get; set; } = 5;

        [Required]
        [Column("manu_id")]
        public long ManuId { get; set; }

        [Required]
        [Column("seg_id")]
        public int SegId { get; set; }

        [ForeignKey(nameof(ManuId))]
        public virtual Manufacturer Manufacturer { get; set; } = null!;

        [ForeignKey(nameof(SegId))]
        public virtual Segment Segment { get; set; } = null!;
    }
}
