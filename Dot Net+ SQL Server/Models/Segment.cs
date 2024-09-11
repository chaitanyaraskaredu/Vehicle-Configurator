using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNetProject.Models
{
    public partial class Segment
    {
   
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Column("seg_name")]
        [JsonPropertyName("name")] 
        public string SegName { get; set; } = null!;

        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Manufacturer> Manufacturers { get; } = new List<Manufacturer>();


        [NotMapped]
        [JsonIgnore]
        public virtual ICollection<Model> Models { get; } = new List<Model>();
    }
}
