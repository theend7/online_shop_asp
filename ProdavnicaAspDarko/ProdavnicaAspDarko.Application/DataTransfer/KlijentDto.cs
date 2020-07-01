using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class KlijentDto
    {
        public long Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Email { get; set; }
        public string Lozinka { get; set; }
       
    }
}
