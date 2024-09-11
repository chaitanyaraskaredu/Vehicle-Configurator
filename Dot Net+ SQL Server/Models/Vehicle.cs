using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DotNetProject.Models
{
    [Table("vehicles")]
    public partial class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [Required]
        [MaxLength(10)]
        [Column("comp_type")]
        public string CompType { get; set; } = null!;

        [Required]
        [MaxLength(10)]
        [Column("is_configurable")]
        public string IsConfigurable { get; set; } = null!;

        [ForeignKey(nameof(CompId))]
        public virtual Component Component { get; set; } = null!;

        [ForeignKey(nameof(ModId))]
        public virtual Model Model { get; set; } = null!;

        [Required]
        [Column("comp_id")]
        public long CompId { get; set; }

        [Required]
        [Column("mod_id")]
        public long ModId { get; set; }
    }
}
