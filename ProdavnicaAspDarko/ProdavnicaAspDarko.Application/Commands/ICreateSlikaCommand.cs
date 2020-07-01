using ProdavnicaAspDarko.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Commands
{
    public interface ICreateSlikaCommand : ICommand<SlikaDto>
    {
    }
}
