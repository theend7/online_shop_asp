using Newtonsoft.Json;
using ProdavnicaAspDarko.Application;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Logging
{
    public class ConsoleUseCaseLogger : IUseCaseLogger
    {
        public void Log(IUseCase useCase, IApplicationActor actor,object data)
        {
            Console.WriteLine($"{DateTime.Now}: {actor.Identity} pokusava da izvrsi {useCase.Name} koristeci podatke: " +
                $"{JsonConvert.SerializeObject(data)}");
        }
    }
}
