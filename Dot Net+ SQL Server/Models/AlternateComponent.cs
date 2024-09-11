using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNetProject.Models
{
    [Table("alternate_components")]
    public partial class AlternateComponent
    {
        [Column("id")]
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [Column("delta_price")]
        [JsonPropertyName("delta_price")]
        public double DeltaPrice { get; set; }

        [Column("comp_id")]
        [JsonPropertyName("comp_id")]
        public long CompId { get; set; }

        
        [Column("mod_id")]
        [JsonPropertyName("mod_id")]
        public long ModId { get; set; }

        
        [Column("alt_comp_id")]
        [JsonPropertyName("alt_comp_id")]
        public long? AltCompId { get; set; }

        public virtual Component Comp { get; set; } = null!;

        public virtual Model Mod { get; set; } = null!;
    }
}
