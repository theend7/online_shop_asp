using ProdavnicaAspDarko.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Queries
{
    public interface IGetProizvodSlikeQuery : IQuery<int, IEnumerable<ProizvodNjegoveSlikeDto>>
    {

    }
}
