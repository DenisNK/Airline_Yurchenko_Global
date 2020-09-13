using Microsoft.AspNetCore.Hosting;
using System;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace Airline_Yurchenko.FiltersApp
{
    public class MyImage<TEntity> : IMyImage<TEntity> where TEntity : class
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public MyImage(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public string UploadedFile(IFormFile profileImage)
        {
            string uniqueFileName = null;

            if (profileImage != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "images");
                uniqueFileName = Guid.NewGuid().ToString() + "_" + profileImage.FileName;
                string filePath = Path.Combine(uploadsFolder, uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    profileImage.CopyTo(fileStream);
                }
            }
            return uniqueFileName;
        }
    }
}
