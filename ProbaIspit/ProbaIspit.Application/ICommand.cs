using System;
using System.Collections.Generic;
using System.Text;

namespace ProbaIspit.Application
{
    public interface ICommand<RequestData> : IUseCase
    {
        void Execute(RequestData request);
    }
    public interface IQuery<Search,Result> : IUseCase
    {
        Result Execute(Search search);
    }
    public interface IUseCase
    {
        public int Id { get; }
        public string Opis { get; }
    }
}
