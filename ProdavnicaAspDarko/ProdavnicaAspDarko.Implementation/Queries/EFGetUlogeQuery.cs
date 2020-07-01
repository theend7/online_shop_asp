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
    public class EFGetUlogeQuery : IGetUlogeQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetUlogeQuery(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id =>17;

        public string Name => "Dohvatanje svih uloga pomocu EF-a";

        public PagedResponse<UlogaDto> Execute(UlogaSearch search)
        {
            var query = context.Uloge.AsQueryable();
            if (!string.IsNullOrEmpty(search.NazivUloge) || !string.IsNullOrWhiteSpace(search.NazivUloge))
            {
                query = query.Where(x => x.NazivUloge.ToLower().Contains(search.NazivUloge.ToLower()));
            }
            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UlogaDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UlogaDto
                {
                    NazivUloge= x.NazivUloge
                   

                }).ToList()
            };
            return response;
        }
    }
}
