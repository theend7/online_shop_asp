using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class UseCaseLog
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }

        public string UseCaseNaziv { get; set; }

        public string Podaci { get; set; }

        public string Actor { get; set; }
    }
}
