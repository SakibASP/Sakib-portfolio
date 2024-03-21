using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAKIB_PORTFOLIO.Models
{
    [Table(nameof(Visitors))]
    public class Visitors
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AutoId { get; set; }
        public string? IPAddress { get; set; }
        public string? Browser { get; set; } // Example: Chrome, Firefox, etc.
        public string? OperatingSystem { get; set; } // Example: Windows, macOS, Linux, etc.
        public string? City { get; set; }
        public string? Country { get; set; }
        public string? Zip { get; set; }
        public string? Timezone { get; set; }
        public string? Isp { get; set; }
        public string? Org { get; set; }
        public string? As { get; set; }
        public DateTime VisitTime { get; set; }

    }
}
