using ProdavnicaAspDarko.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaAspDarko.Api.Core
{
    public class NotLoggedInActor : IApplicationActor
    {
        public int Id => 0;

        public string Identity => "Ne ulogovani klijent";

        public IEnumerable<int> AllowedUseCases => new List<int> { 10,26,1};
    }
}
