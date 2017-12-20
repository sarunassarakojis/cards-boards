using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using GossipBoard.Models;
using Microsoft.AspNetCore.Http;

namespace GossipBoard.Services
{
    public class FileSaveService : IFileSaveService
    {
        public async Task<FileUploadResultDto> Save(IFormFile file)
        {
            if (file == null)
            {
                throw new ArgumentNullException(nameof(file));
            }

            string fileName;
            if (file.Length > 0)
            {
                var filePath = GetFileDirectory();
                fileName = Guid.NewGuid() + file.FileName;
                var fileFullName = Path.Combine(filePath, fileName);
                using (var stream = new FileStream(fileFullName, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }
            }
            else
            {
                throw new ArgumentException("File cannot be empty", nameof(file));
            }

            var result = new FileUploadResultDto
            {
                Size = file.Length,
                FileName = fileName
            };
            return result;
        }

        private string GetFileDirectory()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "images");

            Directory.CreateDirectory(filePath);

            return filePath;
        }
    }
}
