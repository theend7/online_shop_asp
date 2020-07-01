using Newtonsoft.Json;
using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Logging
{
    public class DataBaseUseCaseLogger : IUseCaseLogger
    {
        private readonly ProdavnicaAspDarkoContext _context;

        public DataBaseUseCaseLogger(ProdavnicaAspDarkoContext context)
        {
            _context = context;
        }

        public void Log(IUseCase useCase, IApplicationActor actor, object useCaseData)
        {
            _context.UseCaseLogs.Add(new Domain.UseCaseLog
            {
                Actor = actor.Identity,
                Podaci = JsonConvert.SerializeObject(useCaseData),
                Datum = DateTime.UtcNow,
                UseCaseNaziv = useCase.Name

            });
            _context.SaveChanges();
        }
    }
}
