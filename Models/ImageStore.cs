using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SAKIB_PORTFOLIO.Models
{
    [Table("ImageStore")]
    public class ImageStore
    {
        [Key]
        [HiddenInput(DisplayValue = false)]
        public int AUTO_ID { get; set; }
        public int? PROFILE_ID { get; set; }
        public string? IMG_PATH { get; set; }
        [ForeignKey(nameof(PROFILE_ID))]
        public virtual MY_PROFILE? MY_PROFILE { get; set; }
    }
}
