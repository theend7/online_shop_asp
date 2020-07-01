using Microsoft.EntityFrameworkCore;
using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Queries
{
    public class EFGetJednaPorudzbinaQuery : IGetPorudzbinaByIdQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetJednaPorudzbinaQuery(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 24;

        public string Name => "Prikazivanje jedna porudzbine putem EF-a";

        PorudzbinaSearchDatumDto IQuery<int, PorudzbinaSearchDatumDto>.Execute(int search)
        {
            var query = context.Porudzbine.Include(x => x.DetaljiPorudzbina).AsQueryable().IgnoreQueryFilters();
            query = query.Where(x => x.Id == search);

                var response = query.Select(x => new PorudzbinaSearchDatumDto
                {
                    Adresa = x.Adresa,
                    ImeKlijenta = x.Klijent.Ime,
                    PrezimeKlijenta = x.Klijent.Prezime,
                    NazivProizvoda = x.DetaljiPorudzbina.Select(x => x.Naziv),
                    PorudzbinaStatus = x.PorudzbinaStatus,
                    Kolicine = x.DetaljiPorudzbina.Select(x => x.Kolicina),
                    Cene = x.DetaljiPorudzbina.Select(x => x.Cena)

                }).FirstOrDefault();
                return response;
  
        }
    }
}
