using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class ProizvodSlikaCenaDto
    {
        public string NazivP { get; set; }
        public string OpisP{ get; set; }

        public int KolicinaP{ get; set; }

        public decimal CenaP { get; set; }

        public int IdKategorija { get; set; }

        public virtual List<IFormFile> SlikeP { get; set; }
    }
}
