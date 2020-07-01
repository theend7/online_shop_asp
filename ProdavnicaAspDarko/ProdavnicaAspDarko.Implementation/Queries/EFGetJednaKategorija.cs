using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Queries
{
    public class EFGetJednaKategorija : IGetKategorijaByIdQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetJednaKategorija(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 20;

        public string Name =>"Dohvatanje jedne kategorije pomocu EF-a";

        JednaKategorijaDto IQuery<int, JednaKategorijaDto>.Execute(int search)
        {
            var query = context.Kategorije.AsQueryable();
            query = query.Where(x => x.Id == search);
         
                var response = query.Select(x => new JednaKategorijaDto
                {
                    IdKategorija = x.Id,
                    NazivKategorije = x.NazivKategorije

                }).FirstOrDefault();
                return response;
        }
    }
}
