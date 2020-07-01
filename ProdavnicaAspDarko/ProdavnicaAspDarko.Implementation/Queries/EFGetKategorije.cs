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
    public class EFGetKategorije : IGetKategorijeQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetKategorije(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 21;

        public string Name => "Dohvatanje svih kategorija pomocu EF-a";

        public PagedResponse<KategorijaSearchDto> Execute(KategorijaSearch search)
        {
            var query = context.Kategorije.AsQueryable();


            if (!string.IsNullOrEmpty(search.NazivKategorije) || !string.IsNullOrWhiteSpace(search.NazivKategorije))
            {
                query = query.Where(x => x.NazivKategorije.ToLower().Contains(search.NazivKategorije.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<KategorijaSearchDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new KategorijaSearchDto
                {
                   IdKategorija = x.Id,
                   NazivKategorije = x.NazivKategorije


                }).ToList()
            };
            return response;
        }
    }
}
