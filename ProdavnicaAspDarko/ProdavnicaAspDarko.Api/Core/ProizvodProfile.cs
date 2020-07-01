using AutoMapper;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaAspDarko.Api.Core
{
    public class ProizvodProfile : Profile
    {
        public ProizvodProfile()
        {
            CreateMap<Proizvod, ProizvodDto>();
            CreateMap<ProizvodDto, Proizvod>();
        }
    }
}
