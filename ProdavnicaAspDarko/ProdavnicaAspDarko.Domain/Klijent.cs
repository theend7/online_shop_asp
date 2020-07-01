using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class Klijent : Entity
    {
       
        public long Jmbg { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public string Email { get; set; }
        public string Lozinka { get; set; }
        public int IdUloga { get; set; }

        public virtual Uloga Uloga { get; set; }
        public virtual ICollection<Porudzbina> Porudzbine { get; set; }
        public virtual ICollection<KlijentUseCase> KlijentUseCases { get; set; }

    }
}
