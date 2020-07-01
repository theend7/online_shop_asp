﻿using ProdavnicaAspDarko.Application.DataTransfer;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Application.Queries
{
    public interface IGetProizvodByIdQuery :  IQuery<int, DohvatiProizvodCenuSlikuDto>
    {
    }
}
