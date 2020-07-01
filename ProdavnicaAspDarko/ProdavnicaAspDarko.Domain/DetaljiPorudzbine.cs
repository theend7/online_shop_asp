using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class DetaljiPorudzbine : Entity
    {
        public string Naziv { get; set; }
        public int Kolicina { get; set; }
        public decimal Cena { get; set; }

        public int PorudzbinaId { get; set; }
        public int? ProizvodId { get; set; }

        public virtual Porudzbina Porudzbina { get; set; }
        public virtual Proizvod Proizvod { get; set; }
    }
}
