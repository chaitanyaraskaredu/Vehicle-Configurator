using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace DotNetProject.Models
{
    [Table("car_description")]
    public partial class CarDescription
    {
        [JsonPropertyName("id")]
        [Column("id")]
        public long Id { get; set; }


        [JsonPropertyName("carName")]
        [Column("car_name")]
        public string? CarName { get; set; }

        [JsonPropertyName("description")]
        [Column("description")]
        public string? Description { get; set; }

        [JsonPropertyName("path")]
        [Column("path")]
        public string? Path { get; set; }
    }
}
