using Microsoft.Extensions.Hosting;
using SAKIB_PORTFOLIO.Models;

namespace SAKIB_PORTFOLIO.Common
{
    public static class Utility
    {
        public static byte[]? Getimage(byte[]? img, IFormFileCollection files)
        {
            PROJECTS project = new();
            MemoryStream ms = new();
            if (files != null)
            {
                foreach (var file in files)
                {
                    file.CopyTo(ms);
                    project.LOGO = ms.ToArray();

                    ms.Close();
                    ms.Dispose();

                    img = project.LOGO;
                }
            }
            return img;
        }

        public static string GetFilePathOfCV(IWebHostEnvironment _hostEnvironment)
        {
            string folderPath = Path.Combine(_hostEnvironment.WebRootPath, "CV");
            DirectoryInfo directory = new(folderPath);
            var fullName = directory.GetFiles().OrderByDescending(x => x.LastWriteTime).FirstOrDefault()?.FullName ?? "";
            return fullName;
        }

        public async static Task SaveFileAsync(string filePath, IFormFile file)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
        }
    }
}
