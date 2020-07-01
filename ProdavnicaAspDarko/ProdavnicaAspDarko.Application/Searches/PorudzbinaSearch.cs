using ProdavnicaAspDarko.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Searches
{
    public class PorudzbinaSearch :  PagedSearch
    {
        public DateTime DatumP { get; set; }
    }
}
