using AutoMapper;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProdavnicaAspDarko.Api.Core
{
    public class KategorijaProfile : Profile
    {
        public KategorijaProfile()
        {
            CreateMap<Kategorija, KategorijaDto>();
            CreateMap<KategorijaDto, Kategorija>();
        }
    }
}
