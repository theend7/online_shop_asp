using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Exceptions
{
    public class UnauthorizedUseCaseException : Exception
    {
        public UnauthorizedUseCaseException(IUseCase useCase, IApplicationActor actor) : base($"Actor sa id-ijem{actor.Id} - {actor.Identity} pokusava da izvrsi{useCase.Name}")
        {

        }
    }
}
