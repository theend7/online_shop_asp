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
    public class EFDeleteProizvodCommand : IDeleteProizvodCommand
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFDeleteProizvodCommand(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 25;

        public string Name => "Brisanje proizvoda pomocu EF-a";

        public void Execute(int request)
        {
          
                var proizvod = context.Proizvodi.Find(request);
                if (proizvod == null)
                {
                    throw new EntityNotFoundException(request, typeof(Proizvod));
                }
                var upitDeleteSlika = context.Slike.Where(x => x.ProizvodId == request).AsQueryable();
                foreach (var k in upitDeleteSlika)
                {
                    k.isDeleted = true;
                    k.DeletedAt = DateTime.Now;
                    k.isActive = false;
                    k.ModifiedAt = null;
                }
                var upitDeleteCena = context.Cene.Where(x => x.ProizvodId == request).AsQueryable();
                foreach (var k in upitDeleteCena)
                {
                    k.isDeleted = true;
                    k.DeletedAt = DateTime.Now;
                    k.isActive = false;
                    k.ModifiedAt = null;
                }
                context.SaveChanges();

                proizvod.isDeleted = true;
                proizvod.DeletedAt = DateTime.Now;
                proizvod.isActive = false;
                proizvod.ModifiedAt = null;
                context.SaveChanges();
          
            
        }
    }
}
