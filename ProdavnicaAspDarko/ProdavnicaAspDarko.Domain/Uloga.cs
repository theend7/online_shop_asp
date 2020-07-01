using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class Uloga : Entity
    {
        public string NazivUloge { get; set; }
        public virtual ICollection<Klijent> Klijenti { get; set; }
    }
}
