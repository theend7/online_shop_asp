using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class Cena : Entity
    {
        public decimal CenaP { get; set; }

        public int ProizvodId { get; set; }

        public virtual Proizvod Proizvod { get; set; }
    }
}
