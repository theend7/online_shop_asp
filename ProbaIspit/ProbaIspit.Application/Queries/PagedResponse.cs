using System;
using System.Collections.Generic;
using System.Text;

namespace ProbaIspit.Application.Queries
{
    public class PagedResponse<T> where T : class
    {
        public int UkupanBrojStavki { get; set; }
        public int TrenutnaStrana { get; set; }
        public int StavkePoStrani { get; set; }
        public IEnumerable<T> Stavke { get; set; }

        public int BrojStrana => (int)Math.Ceiling((float)UkupanBrojStavki / StavkePoStrani);
    }
}
