using ProdavnicaAspDarko.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Commands
{
    public interface ICreateUlogaCommand : ICommand<UlogaDto>
    {
    }
}
