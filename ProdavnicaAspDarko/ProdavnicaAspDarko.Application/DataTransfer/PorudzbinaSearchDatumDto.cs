using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class PorudzbinaSearchDatumDto
    {

     

        public string Adresa { get; set; }

        public string ImeKlijenta { get; set; }
        public string PrezimeKlijenta { get; set; }

        public IEnumerable<string> NazivProizvoda { get; set; }

        public PorudzbinaStatus PorudzbinaStatus { get; set; }

        public IEnumerable<int> Kolicine { get; set; }
        public IEnumerable<decimal> Cene  { get; set; }



}
}
