using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAKIB_PORTFOLIO.Models
{
    [Table("PROJECTS")]
    public class PROJECTS
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AUTO_ID { get; set; }
        public string? PROJECT_NAME { get; set; }

        [DisplayName("Image")]
        public byte[]? LOGO { get; set; }
        [DisplayName("Desc. 1")]
        public string? DESCRIPTION_1 { get; set; }
        [DisplayName("Desc. 2")]
        public string? DESCRIPTION_2 { get; set; }
        [DisplayName("Desc. 3")]
        public string? DESCRIPTION_3 { get; set; }
        [DisplayName("Desc. 4")]
        public string? DESCRIPTION_4 { get; set; }
        [DisplayName("Desc. 5")]
        public string? DESCRIPTION_5 { get; set; }
        [DisplayName("Desc. 6")]
        public string? DESCRIPTION_6 { get; set; }
    }
}
