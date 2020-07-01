using ProdavnicaAspDarko.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Queries
{
    public interface IGetUlogaByIdQuery : IQuery<int, JednaUlogaDto>
    {
    }
}
