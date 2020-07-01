using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class DohvatiProizvodCenuSlikuDto
    {
        public string NazivP { get; set; }
        public string OpisP { get; set; }
        public decimal CenaP { get; set; }
        public string SlikaP { get; set; }

        public IEnumerable<string> Slike { get; set; } 

        public int KolicinaP { get; set; }
        public int IdKategorija { get; set; }
    }
}
