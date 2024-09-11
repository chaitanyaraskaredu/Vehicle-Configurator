using System.Collections.Generic;

namespace DotNetProject.Models
{
    public class SegmentDto
    {
        public int Id { get; set; }
        public string SegName { get; set; } = null!;
        public ICollection<Manufacturer>? Manufacturers { get; set; }
        public ICollection<Model>? Models { get; set; }
    }
}
