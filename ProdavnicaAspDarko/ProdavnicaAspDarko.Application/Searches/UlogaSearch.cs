using ProdavnicaAspDarko.Application.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Searches
{
    public class UlogaSearch :  PagedSearch
    {
        public string NazivUloge { get; set; }
    }
}
