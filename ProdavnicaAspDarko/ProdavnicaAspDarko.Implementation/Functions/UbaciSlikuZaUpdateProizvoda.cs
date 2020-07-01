using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Functions
{
    public class UbaciSlikuZaUpdateProizvoda
    {
       public  static string UbaciSlikuUpdate(IFormFile slikaProizvoda)
        {
            var guid = Guid.NewGuid();
            var extension = Path.GetExtension(slikaProizvoda.FileName);

            var newFileName = guid + extension;

            var path = Path.Combine("wwwroot", "images", newFileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                slikaProizvoda.CopyTo(fileStream);
            }
            return newFileName;
        }
    }
}
