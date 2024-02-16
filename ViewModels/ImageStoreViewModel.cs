using System.ComponentModel.DataAnnotations;

namespace SAKIB_PORTFOLIO.ViewModels
{
    public class ImageStoreViewModel
    {
        [Required(ErrorMessage = "Please select an image file.")]
        [Display(Name = "Image File")]
        public IFormFile? ImageFile { get; set; }
    }
}
