using ProdavnicaAspDarko.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Searches
{
    public class UseCaseLogSearch : PagedSearch
    {
        public string EmailKlijenta { get; set; }
        public DateTime Datum { get; set; }

        public string NazivUseCase { get; set; }

        public bool NeUlogovaniKlijent { get; set; }
    }
}
