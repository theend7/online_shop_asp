using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProbaIspit.Application
{
    public class UseCaseExecutor
    {
        private readonly IActorInApp actor;

        public UseCaseExecutor(IActorInApp actor)
        {
            this.actor = actor;
        }
        public Result ExecuteQuery<Search,Result>(IQuery<Search,Result> query,Search search)
        {
            if (!actor.AllowedUseCases.Contains(query.Id))
            {
                throw new ArgumentException("Nemate pravo da izvrsite ovu komandu!");
            }
            return query.Execute(search);
        }
        public void ExecuteCommand<RequestData>(ICommand<RequestData> command,RequestData request)
        {
            if (!actor.AllowedUseCases.Contains(command.Id))
            {
                throw new ArgumentException("Nemate pravo da izvrsite ovu komandu!");
            }
             command.Execute(request);
        }
    }
}
