using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SAKIB_PORTFOLIO.Data;
using SAKIB_PORTFOLIO.Models;
using SAKIB_PORTFOLIO.ViewModels;

namespace SAKIB_PORTFOLIO.Controllers
{
    [Authorize]
    public class ImageStoreController : Controller
    {
        private readonly ApplicationDbContext _context;
        public ImageStoreController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var images = _context.ImageStore.ToList();
            return View(images);
        }  
        
        public IActionResult UploadImage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage(ImageStoreViewModel model)
        {
            if (ModelState.IsValid)
            {
                if (model.ImageFile != null && model.ImageFile.Length > 0)
                {
                    var imagePath = "uploads/" + model.ImageFile.FileName;
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", imagePath);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }

                    var image = new ImageStore { IMG_PATH = imagePath };
                    _context.ImageStore.Add(image);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult DeleteImage(int id)
        {
            // Find the image record in the database
            var image = _context.ImageStore.FirstOrDefault(i => i.AUTO_ID == id);

            if (image == null)
            {
                return NotFound(); // Return a 404 Not Found if the image is not found
            }

            // Construct the full file path to the image
            var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.IMG_PATH!);

            // Check if the image file exists
            if (System.IO.File.Exists(imagePath))
            {
                // Delete the image file from the server's file system
                System.IO.File.Delete(imagePath);
            }

            // Remove the image record from the database
            _context.ImageStore.Remove(image);
            _context.SaveChanges();

            return NoContent(); // Return a 204 No Content response to indicate successful deletion
        }

    }
}
