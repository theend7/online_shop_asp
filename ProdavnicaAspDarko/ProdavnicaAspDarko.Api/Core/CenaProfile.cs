using AutoMapper;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaAspDarko.Api.Core
{
    public class CenaProfile : Profile
    {
        public CenaProfile()
        {
            CreateMap<Cena, CenaDto>();
            CreateMap<CenaDto, Cena>();
        }
    }
}
