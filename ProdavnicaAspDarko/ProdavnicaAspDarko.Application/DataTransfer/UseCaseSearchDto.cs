using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class UseCaseSearchDto
    {
        public DateTime Datum { get; set; }
        public string UseCaseNaziv { get; set; }

        public string Podaci { get; set; }

        public string Actor { get; set; }
    }
}
