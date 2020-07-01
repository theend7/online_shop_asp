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
    public class EFGetOneKlijent : IGetKlijentById
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetOneKlijent(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 14;

        public string Name => "Dohvatanje jednog klijenta pomocu EF-a";

        JedanKlijentDto IQuery<int, JedanKlijentDto> . Execute(int search)
        {
            var query = context.Klijenti.AsQueryable();
            query = query.Where(x => x.Id == search);
            var response = query.Select(x => new JedanKlijentDto
                {
                    Ime = x.Ime,
                    Prezime = x.Prezime,
                    Email = x.Email,
                    IdUloga = x.IdUloga,
                    Jmbg = x.Jmbg

                }).FirstOrDefault();
                return response;
        }

    }
}
