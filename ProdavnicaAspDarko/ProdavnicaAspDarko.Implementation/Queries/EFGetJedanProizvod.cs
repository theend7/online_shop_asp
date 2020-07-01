using Microsoft.EntityFrameworkCore;
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
    public class EFGetJedanProizvod : IGetProizvodByIdQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFGetJedanProizvod(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 26;

        public string Name => "Dohvatanja jednog proizvoda pomocu EF-a";

        DohvatiProizvodCenuSlikuDto IQuery<int, DohvatiProizvodCenuSlikuDto>.Execute(int search)
        {
            var query = context.Proizvodi.Include(x => x.Cene).AsQueryable();
            query = query.Where(x => x.Id == search);
            var response = query.Select(x => new DohvatiProizvodCenuSlikuDto

                {
                    NazivP = x.NazivProizvoda,
                    OpisP = x.OpisProizvoda,
                    KolicinaP = x.KolicinaProizvoda,
                    SlikaP = x.SlikaProizvoda,
                    Slike = x.Slike.Select(x => x.SlikaPutanja),
                    CenaP = x.Cene.OrderByDescending(x => x.Id).Select(x => x.CenaP).First(),
                    IdKategorija = x.IdKategorija

                }).FirstOrDefault();
                return response;
            
        }
    }
}
