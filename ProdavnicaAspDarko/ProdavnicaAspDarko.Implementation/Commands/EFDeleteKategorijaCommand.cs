using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFDeleteKategorijaCommand : IDeleteKategorijaCommand
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFDeleteKategorijaCommand(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 22;

        public string Name => "Brisanje kategorije pomocu EF-a";

        public void Execute(int request)
        {
                var kategorija = context.Kategorije.Find(request);
                if (kategorija == null)
                {
                    throw new EntityNotFoundException(request, typeof(Kategorija));
                }
                var ulogaDelete = context.Kategorije.Where(x => x.Id == request).AsQueryable();

                var upitDeleteProizvod = context.Proizvodi.Where(x => x.IdKategorija == request).AsQueryable();
                foreach (var p in upitDeleteProizvod)
                {
                    p.isDeleted = true;
                    p.DeletedAt = DateTime.Now;
                    p.isActive = false;
                    p.ModifiedAt = null;
                }
                context.SaveChanges();

                kategorija.isDeleted = true;
                kategorija.DeletedAt = DateTime.Now;
                kategorija.isActive = false;
                kategorija.ModifiedAt = null;
                context.SaveChanges();
           

              
        }
    }
}
