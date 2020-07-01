using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class SlikaDto
    {
        public int IdProizvod { get; set; }

        public List<IFormFile> SlikeProizvoda { get; set; }
    }
}
