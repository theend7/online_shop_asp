using Microsoft.EntityFrameworkCore;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Application.Searches;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Queries
{
    public class EFGetKlijentiQuery : IGetKlijentiQuery
    {

        private readonly ProdavnicaAspDarkoContext context;

        public EFGetKlijentiQuery(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }
        public int Id => 11;

        public string Name =>"Pretraga Klijenata pomocu EF-a";

        public PagedResponse<KlijentSearchDto> Execute(KlijentSearch search)
        {
            var query = context.Klijenti.Include(x=>x.Uloga).AsQueryable();


            if (!string.IsNullOrEmpty(search.ImeIliPrezimeKlijenta) ||  !string.IsNullOrWhiteSpace(search.ImeIliPrezimeKlijenta))
            {
                query = query.Where(x => x.Ime.ToLower().Contains(search.ImeIliPrezimeKlijenta.ToLower()) || x.Prezime.ToLower().Contains(search.ImeIliPrezimeKlijenta.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<KlijentSearchDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new KlijentSearchDto
                {
                    Jmbg = x.Jmbg,
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Email = x.Email,
                    IdUloga = x.IdUloga,
                    NazivUloge = x.Uloga.NazivUloge,

                }).ToList()
            };
            return response;
        }
    }
}
