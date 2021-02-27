using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Core.Utilities.FileHelper
{
    public class FileHelper
    {
        public static string Add(IFormFile file)
        {
            var result = newPath(file);
            var sourcepath = Path.GetTempFileName();
            if (file.Length > 0)
            {
                using (var stream = new FileStream(sourcepath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }

            File.Move(sourcepath, result);
            return result;

        }
        public static string Update(string sourcePath, IFormFile file)
        {
            var result = newPath(file);
            if (sourcePath.Length > 0)
            {
                using (var stream = new FileStream(result, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            File.Delete(sourcePath);
            return result;

        }
        public static void Delete(string path)
        {
            File.Delete(path);
        }

        public static string newPath(IFormFile file)
        {

            FileInfo fileInfo = new FileInfo(file.FileName);
            string fileExtension = fileInfo.Extension;

            var creatingUniqueFilename = Guid.NewGuid().ToString()
               + "_" + DateTime.Now.Millisecond + "_"
               + DateTime.Now.Minute + "_"
               + DateTime.Now.Hour + fileExtension;

            //string path = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).FullName + @"\Images");

            string path = Environment.CurrentDirectory + @"\wwwroot\uploads";

            string result = $@"{path}\{creatingUniqueFilename}";

            return result;
        }

    }
}
