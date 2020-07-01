using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class Proizvod : Entity
    {
        public string NazivProizvoda { get; set; }
        public string OpisProizvoda { get; set; }
        public int KolicinaProizvoda { get; set; }

        public string SlikaProizvoda { get; set; }

        public int IdKategorija { get; set; }
        public virtual Kategorija Kategorija { get; set; }
        public virtual ICollection<Cena> Cene { get; set; }
        public virtual ICollection<Slika> Slike { get; set; }
        public virtual ICollection<DetaljiPorudzbine> DetaljiPorudzbina { get; set; } = new HashSet<DetaljiPorudzbine>();
    }
}
