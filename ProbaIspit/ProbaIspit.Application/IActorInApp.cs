using System;
using System.Collections.Generic;
using System.Text;

namespace ProbaIspit.Application
{
    public interface IActorInApp
    {
        public int Id { get; }
        public string Identity { get; }
        public IEnumerable<int> AllowedUseCases { get; }
    }
}
