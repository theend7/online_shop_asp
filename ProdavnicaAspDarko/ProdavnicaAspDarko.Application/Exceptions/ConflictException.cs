using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Exceptions
{
    public class ConflictException :  Exception
    {
        public ConflictException(string naziv, Type type) : base($"Entitet tipa {type.Name} sa nazivom {naziv} postoji u bazi")
        {

        }
    }
}
