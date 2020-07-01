using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class ProizvodDto
    {
        public string NazivProizvoda { get; set; }
        public string OpisProizvoda { get; set; }
        public int KolicinaProizvoda { get; set; }

        public string SlikaProizvoda { get; set; }

        public int IdKategorija { get; set; }
    }
}
