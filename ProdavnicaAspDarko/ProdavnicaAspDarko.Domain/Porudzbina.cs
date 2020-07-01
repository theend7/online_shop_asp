using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class Porudzbina : Entity
    {
        public DateTime DatumPorudzbine { get; set; }
        public int KlijentId { get; set; }
        public string Adresa { get; set; }
        public  PorudzbinaStatus PorudzbinaStatus { get; set; }

        public virtual Klijent Klijent { get; set; }
        public virtual ICollection<DetaljiPorudzbine> DetaljiPorudzbina { get; set; } = new HashSet<DetaljiPorudzbine>();
    }
    public enum PorudzbinaStatus
    {
        Primljena,
        Poslata,
        Isporucena,
        Otkazana
    }
}
