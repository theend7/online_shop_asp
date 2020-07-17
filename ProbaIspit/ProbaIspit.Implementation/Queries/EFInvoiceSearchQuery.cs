using Microsoft.EntityFrameworkCore;
using ProbaIspit.Application.DataTransfer;
using ProbaIspit.Application.Queries;
using ProbaIspit.Application.Searches;
using ProbaIspit.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProbaIspit.Implementation.Queries
{
    public class EFInvoiceSearchQuery : IQueryInvoiceSearch
    {
        private readonly ChinookContext context;

        public EFInvoiceSearchQuery(ChinookContext context)
        {
            this.context = context;
        }

        public int Id =>1;

        public string Opis => "Pretrazivanje fakture pomocu EF-a";

        public PagedResponse<InvoiceDto> Execute(InvoiceSearch search)
        {
            var query = context.Invoice.Include(x => x.InvoiceLine).ThenInclude(x => x.Track).AsQueryable();

            if(!string.IsNullOrEmpty(search.NazivPesme) || !string.IsNullOrWhiteSpace(search.NazivPesme))
            {
                query = query.Where(x => x.InvoiceLine.Any(x => x.Track.Name.ToLower().Contains(search.NazivPesme.ToLower())));
            }
            if (!string.IsNullOrEmpty(search.NazivKompanije) || !string.IsNullOrWhiteSpace(search.NazivKompanije))
            {
                query = query.Where(x => x.Customer.Company.ToLower().Contains(search.NazivKompanije.ToLower()));
            }
            if (!string.IsNullOrEmpty(search.NazivDrzave) || !string.IsNullOrWhiteSpace(search.NazivDrzave))
            {
                query = query.Where(x => x.Customer.State.ToLower().Contains(search.NazivDrzave.ToLower()));
            }
            if(search.IdKupca > 0)
            {
                query = query.Where(x => x.CustomerId == search.IdKupca);
            }


            var skipCount = search.PoStrani * (search.Strana - 1);
            var odgovor = new PagedResponse<InvoiceDto>
            {
                TrenutnaStrana = search.Strana,
                StavkePoStrani = search.PoStrani,
                UkupanBrojStavki = query.Count(),
                Stavke = query.Skip(skipCount).Take(search.PoStrani).Select(x => new InvoiceDto
                {
                    Id = x.InvoiceId,
                    ImeKupca = x.Customer.FirstName,
                    PrezimeKupca = x.Customer.LastName,
                    EmailKupca = x.Customer.Email,
                    TelefonKupca = x.Customer.Phone,
                    BilingAdresa = x.BillingAddress,
                    BilingDrzava = x.BillingState,
                    BilingGrad = x.BillingCity,
                    BilingZemlja = x.BillingCountry,
                    BilingPostanskiKod = x.BillingPostalCode,
                    StavkeFakture = x.InvoiceLine.Where(y=>y.InvoiceId == x.InvoiceId).Select(x => new InvoiceLineDto
                    {
                        Id = x.InvoiceId,
                        NazivPesme = x.Track.Name,
                        Cena = x.UnitPrice,
                        Kolicina = x.Quantity
                    }).ToList()
                })
            };
            return odgovor;
        }
    }
}
