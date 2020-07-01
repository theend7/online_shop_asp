using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class Kategorija : Entity
    {
        public string NazivKategorije { get; set; }
        public virtual ICollection<Proizvod> Proizvodi { get; set; }
    }
}
