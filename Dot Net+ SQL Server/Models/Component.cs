using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNetProject.Models
{
    [Table("components")]
    public partial class Component
    {
        [JsonPropertyName("id")]
        public long Id { get; set; }

        [JsonPropertyName("comp_name")]
        [Column("comp_name")]
        public string? CompName { get; set; }

        [JsonIgnore]
        public virtual ICollection<AlternateComponent> AlternateComponents { get; } = new List<AlternateComponent>();

        [JsonIgnore]
        public virtual ICollection<Vehicle> Vehicles { get; } = new List<Vehicle>();
    }
}
