using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application
{
    public interface IApplicationActor
    {
        public int Id { get; }

        public string Identity { get;  }
        IEnumerable<int> AllowedUseCases { get; }
    }
}
