using Microsoft.AspNetCore.Http;
using ProdavnicaAspDarko.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Functions
{
    public class UbaciSlike
    {
        
        public static List<string> UbaciSlikeProizvoda(List<IFormFile> SlikeP)
        {
            var slikaPutanja = new List<string>();
            foreach(var slika in SlikeP)
            {
                var guid = Guid.NewGuid();
                var extension = Path.GetExtension(slika.FileName);

                var newFileName = guid + extension;

                var path = Path.Combine("wwwroot", "images", newFileName);

                using (var fileStream = new FileStream(path, FileMode.Create))
                {
                    slika.CopyTo(fileStream);
                }
                slikaPutanja.Add(newFileName);
            }
            return slikaPutanja;
        }
    }
}
