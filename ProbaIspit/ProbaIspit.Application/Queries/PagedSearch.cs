using System;
using System.Collections.Generic;
using System.Text;

namespace ProbaIspit.Application.Queries
{
    public abstract class PagedSearch
    {
        public int PoStrani { get; set; } = 3;

        public int Strana { get; set; } = 1;
    }
}
