using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAKIB_PORTFOLIO.Models
{
    [Table("DESCRIPTION_TYPE")]
    public class DESCRIPTION_TYPE
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AUTO_ID { get; set; }
        public string? TYPE { get; set; }
    }
}
