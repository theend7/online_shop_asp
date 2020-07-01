using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class Slika : Entity
    {
        public string SlikaPutanja { get; set; }

        public int ProizvodId { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}
