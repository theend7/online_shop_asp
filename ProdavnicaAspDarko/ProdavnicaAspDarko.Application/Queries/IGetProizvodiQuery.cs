using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Queries
{
    public interface IGetProizvodiQuery : IQuery<ProizvodSearch,PagedResponse<DohvatiProizvodCenuSlikuDto>>
    {

    }
}
