using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAKIB_PORTFOLIO.Models
{
    [Table("EXPERIENCE")]
    public class EXPERIENCE
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AUTO_ID { get; set; }
        [DisplayName("Designation")]
        public string? DESIGNATION { get; set; }
        [DisplayName("From Date")]
        public string? FROM_DATE { get; set; }
        [DisplayName("To Date")]
        public string? TO_DATE { get; set; }
        [DisplayName("Institute")]
        public string? INSTITUTE { get; set; }
        //[DisplayName("Desc. 1")]
        //public string? DES_1 { get; set; }
        //[DisplayName("Desc. 2")]
        //public string? DES_2 { get; set; }
        //[DisplayName("Desc. 3")]
        //public string? DES_3 { get; set; }
        //[DisplayName("Desc. 4")]
        //public string? DES_4 { get; set; }
    }
}
