using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyBlog.Presentation.Extentions
{
    public static class FormFileExtention
    {

        public static async Task<byte[]> StringToByteArrayAsync(this IFormFile formFile)
        {
            using MemoryStream memory = new MemoryStream();
            await formFile.CopyToAsync(memory);
            return memory.ToArray();
        }
        public static async Task<TimeSpan> CalculeTimeForString(this string value)
        {
            var lenght = value.Length;
            int x = lenght / 5;
            return TimeSpan.FromMinutes(x+1);

        }
    }
}
