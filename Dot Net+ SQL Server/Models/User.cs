using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;

namespace DotNetProject.Models
{
    [Table("user")]
    public partial class User
    {
        private static readonly Random _random = new Random();

        [Key]
        [Column("userid")]
        [JsonPropertyName("userid")]
        public string Userid
        {
            get => _userid;
            set
            {
                _userid = string.IsNullOrEmpty(value) ? GenerateRandomUserId() : value;
            }
        }

        private string _userid = GenerateRandomUserId(); 

        [Column("address_line1")]
        [JsonPropertyName("address_line1")]
        public string? AddressLine1 { get; set; }

        [Column("address_line2")]
        [JsonPropertyName("address_line2")]
        public string? AddressLine2 { get; set; }

        [Column("city")]
        [JsonPropertyName("city")]
        public string? City { get; set; }

        [Column("company_name")]
        [JsonPropertyName("company_name")]
        public string? CompanyName { get; set; }

        [Column("email")]
        [JsonPropertyName("email")]
        public string? Email { get; set; }

        [Column("gst_number")]
        [JsonPropertyName("gst_number")]
        public string? GstNumber { get; set; }

        [Column("password")]
        [JsonPropertyName("password")]
        public string? Password { get; set; }

        [Column("pin_code")]
        [JsonPropertyName("pin_code")]
        public string? PinCode { get; set; }

        [Column("state")]
        [JsonPropertyName("state")]
        public string? State { get; set; }

        [Column("telephone")]
        [JsonPropertyName("telephone")]
        public string? Telephone { get; set; }

        [Column("username")]
        [JsonPropertyName("username")]
        public string? Username { get; set; }

        private static string GenerateRandomUserId()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Range(1, 10).Select(_ => chars[_random.Next(chars.Length)]).ToArray());
        }
    }
}
