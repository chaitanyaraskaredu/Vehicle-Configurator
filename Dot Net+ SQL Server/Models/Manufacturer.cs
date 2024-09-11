using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNetProject.Models
{
    [Table("manufacturers")]
    public partial class Manufacturer
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("name")]
        [Column("manu_name")]
        public string ManuName { get; set; } = null!;

        [Column("seg_id")] 
        [JsonIgnore]
        public int SegId { get; set; }

        [JsonIgnore]
        [NotMapped]
        public virtual ICollection<Model> Models { get; } = new List<Model>();

        [JsonIgnore]
        [NotMapped]
        public virtual Segment Seg { get; set; } = null!;
    }
}
