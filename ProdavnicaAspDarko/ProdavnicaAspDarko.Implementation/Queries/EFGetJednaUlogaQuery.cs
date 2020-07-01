using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Cache;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Queries
{
    public class EFGetJednaUlogaQuery : IGetUlogaByIdQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetJednaUlogaQuery(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 16;

        public string Name => "Dohvatanje Jedne Uloge pomocu EF-a";

        JednaUlogaDto IQuery<int, JednaUlogaDto>.Execute(int search)
        {
            var query = context.Uloge.AsQueryable();
            query = query.Where(x => x.Id == search);
                var response = query.Select(x => new JednaUlogaDto

                {
                    IdUloge = x.Id,
                    NazivUloge = x.NazivUloge

                }).FirstOrDefault();
                return response;
            

          
        }
    }
}
