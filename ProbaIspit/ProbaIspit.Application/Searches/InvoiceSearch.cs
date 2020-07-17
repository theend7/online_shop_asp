using ProbaIspit.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbaIspit.Application.Searches
{
    public class InvoiceSearch : PagedSearch
    {
        public int IdKupca { get; set; }
        public string NazivPesme { get; set; }

        public string NazivKompanije { get; set; }

        public string NazivDrzave { get; set; }

        public decimal MinCena { get; set; }
        public decimal MaxCena { get; set; }
    }
}
