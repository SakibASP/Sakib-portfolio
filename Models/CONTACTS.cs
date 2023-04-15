using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAKIB_PORTFOLIO.Models
{
    [Table("CONTACTS")]
    public class CONTACTS
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AUTO_ID { get; set; }
        public int? IsConfirmed { get; set; }
        [DisplayName("Name")]
        public string? NAME { get; set; }
        [DisplayName("Subject")]
        public string? SUBJECT { get; set; }
        [DisplayName("Message")]
        public string? MESSAGE { get; set; }
        [DisplayName("E-mail")]
        public string? EMAIL { get; set; }
        [DisplayName("Phone")]
        public string? PHONE { get; set; }
    }
}
