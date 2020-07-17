using ProbaIspit.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProbaIspit.Api.Core
{
    public class UnAuthorizedActor : IActorInApp
    {
        public int Id =>0;

        public string Identity => "Neautorizovani korisnik";

        public IEnumerable<int> AllowedUseCases => new List<int> {1,2,3,4,5 };
    }
}
