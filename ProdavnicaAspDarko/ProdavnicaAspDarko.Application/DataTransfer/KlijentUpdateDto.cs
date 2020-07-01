using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class KlijentUpdateDto 
    {
        public int IdKlijentUpdate { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int IdUloga { get; set; }
    }
}
