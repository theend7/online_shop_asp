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
    public class EFGetUseCaseLogQuery : IGetUseCaseLogsQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetUseCaseLogQuery(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }
        public int Id => 13;

        public string Name =>"Dohvatanje Logova iz baze pomocu EF-a";

        public PagedResponse<UseCaseSearchDto> Execute(UseCaseLogSearch search)
        {
            var query = context.UseCaseLogs.AsQueryable();


            if (!string.IsNullOrEmpty(search.NazivUseCase) || !string.IsNullOrWhiteSpace(search.NazivUseCase))
            {
                query = query.Where(x => x.UseCaseNaziv.ToLower().Contains(search.NazivUseCase.ToLower()));
            }
            if (search.Datum != new DateTime())
            {
                query = query.Where(x => x.Datum.Date.ToString() == search.Datum.Date.ToString("yyyy-MM-dd"));
            }

            if (!string.IsNullOrEmpty(search.EmailKlijenta) || !string.IsNullOrWhiteSpace(search.EmailKlijenta))
            {
                if (search.NeUlogovaniKlijent != false)
                {
                    query = query.Where(x => x.Actor.ToLower().Contains(search.EmailKlijenta.ToLower()));
                }
                else
                {
                    query = query.Where(x => x.Actor.ToLower().Contains(search.EmailKlijenta.ToLower()));
                }
            }
            else
            {
                if (search.NeUlogovaniKlijent != false)
                {
                    query = query.Where(x => x.Actor == "Ne ulogovani klijent");
                }
            }

            var skipCount = search.PerPage * (search.Page - 1);

            var response = new PagedResponse<UseCaseSearchDto>
            {
                CurrentPage = search.Page,
                ItemsPerPage = search.PerPage,
                TotalCount = query.Count(),
                Items = query.Skip(skipCount).Take(search.PerPage).Select(x => new UseCaseSearchDto
                {
                    UseCaseNaziv = x.UseCaseNaziv,
                    Podaci = x.Podaci,
                    Actor = x.Actor,
                    Datum = x.Datum
                    

                }).ToList()
            };
            return response;
        }
    }
}
