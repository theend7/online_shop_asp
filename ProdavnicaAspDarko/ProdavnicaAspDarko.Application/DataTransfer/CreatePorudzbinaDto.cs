using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.DataTransfer
{
    public class CreatePorudzbinaDto
    {
        public DateTime PorudzbinaDatum { get; set; }
        public string Adresa { get; set; }
        public IEnumerable<CreateDetaljiPorudzbineDto> Items { get; set; } = new List<CreateDetaljiPorudzbineDto>();


    }
    public class CreateDetaljiPorudzbineDto
    {
        public int ProizvodId { get; set; }
        public int Kolicina { get; set; }
        public int IdCena { get; set; }
    }
    public class CreateChangeStatusPorudzbineDto
    {
        public int IdPorudzbina { get; set; }
        public PorudzbinaStatus Status { get; set; }
    }
}
