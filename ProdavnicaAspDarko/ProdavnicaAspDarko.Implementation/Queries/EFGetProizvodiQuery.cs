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
    public class EFGetProizvodiQuery : IGetProizvodiQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetProizvodiQuery(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id =>10;

        public string Name => "Pretraga proizvoda";

        public PagedResponse<DohvatiProizvodCenuSlikuDto> Execute(ProizvodSearch search)
        {
            var query = context.Proizvodi.Include(x=>x.Cene).AsQueryable();


            if (!string.IsNullOrEmpty(search.NazivProizvoda) || !string.IsNullOrWhiteSpace(search.NazivProizvoda))
            {
                query = query.Where(x => x.NazivProizvoda.ToLower().Contains(search.NazivProizvoda.ToLower()));
            }
            var skipCount = search.PerPage *( search.Page - 1);

            var response = new PagedResponse<DohvatiProizvodCenuSlikuDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new DohvatiProizvodCenuSlikuDto
                {
                    NazivP = x.NazivProizvoda,
                    OpisP = x.OpisProizvoda,
                    KolicinaP = x.KolicinaProizvoda,
                    SlikaP = x.SlikaProizvoda,
                    Slike = x.Slike.Select(x => x.SlikaPutanja),
                    CenaP = x.Cene.OrderByDescending(x => x.Id).Select(x=>x.CenaP).First(),
                    IdKategorija = x.IdKategorija
                    
                }).ToList()
            };
            return response;
           
        }
    }
}
