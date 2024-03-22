using Microsoft.Extensions.Hosting;
using SAKIB_PORTFOLIO.Models;

namespace SAKIB_PORTFOLIO.Common
{
    public static class Utility
    {
        public static byte[]? Getimage(byte[]? img, IFormFileCollection files)
        {
            MY_PROFILE mY_PROFILE = new MY_PROFILE();
            MemoryStream ms = new MemoryStream();
            if (files != null)
            {
                foreach (var file in files)
                {
                    file.CopyTo(ms);
                    mY_PROFILE.PROFILE_IMAGE = ms.ToArray();

                    ms.Close();
                    ms.Dispose();

                    img = mY_PROFILE.PROFILE_IMAGE;
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
    }
}
