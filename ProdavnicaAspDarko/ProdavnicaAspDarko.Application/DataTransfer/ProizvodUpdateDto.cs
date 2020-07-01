using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class ProizvodUpdateDto
    {
        public int IdProizvoda { get; set; }
        public string NazivProizvoda { get; set; }

        public string OpisProizvoda { get; set; }

        public  int Kolicina { get; set; }

        public decimal Cena { get; set; }
        public IFormFile Slika { get; set; }
    }
}
