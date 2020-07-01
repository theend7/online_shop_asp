using Microsoft.EntityFrameworkCore;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Application.Searches;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Queries
{
    public class EFGetPorudzbinaDatum : IGetPorudzbineQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetPorudzbinaDatum(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 12;

        public string Name => "Dohvatanje Porudzbine Preko Datuma putem EF-a";

        public PagedResponse<PorudzbinaSearchDatumDto> Execute(PorudzbinaSearch search)
        {
            var query = context.Porudzbine.Include(x => x.DetaljiPorudzbina).AsQueryable();
            if (search.DatumP != new DateTime())
            {
                query = query.Where(x => x.DatumPorudzbine.Date.ToString() == search.DatumP.Date.ToString("yyyy-MM-dd"));
            }
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<PorudzbinaSearchDatumDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new PorudzbinaSearchDatumDto
                {
                   
                    Adresa = x.Adresa,
                    ImeKlijenta = x.Klijent.Ime,
                    PrezimeKlijenta = x.Klijent.Prezime,
                    NazivProizvoda = x.DetaljiPorudzbina.Select(x=>x.Naziv),
                    PorudzbinaStatus = x.PorudzbinaStatus,
                    Kolicine = x.DetaljiPorudzbina.Select(x=>x.Kolicina),
                    Cene = x.DetaljiPorudzbina.Select(x=>x.Cena)

                }).ToList()
            };
            return response;
        }
    }
}
