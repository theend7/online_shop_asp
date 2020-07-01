using ProdavnicaAspDarko.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Searches
{
    public class KategorijaSearch : PagedSearch
    {
        public string NazivKategorije { get; set; }
    }
}
