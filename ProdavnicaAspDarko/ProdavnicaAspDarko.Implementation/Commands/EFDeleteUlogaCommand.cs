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
    public class EFDeleteUlogaCommand : IDeleteUlogaCommand
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFDeleteUlogaCommand(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 18;

        public string Name => "Brisanje uloge pomocu EF-a";

        public void Execute(int request)
        {
                var uloga = context.Uloge.Find(request);
                if (uloga == null)
                {
                    throw new EntityNotFoundException(request, typeof(Uloga));
                }
                var ulogaDelete = context.Uloge.Where(x => x.Id == request).AsQueryable();
                var upitDeleteKlijent = context.Klijenti.Where(x => x.IdUloga == request).AsQueryable();
                foreach (var k in upitDeleteKlijent)
                {
                    k.isDeleted = true;
                    k.DeletedAt = DateTime.Now;
                    k.isActive = false;
                    k.ModifiedAt = null;
                }
                context.SaveChanges();
                uloga.isDeleted = true;
                uloga.DeletedAt = DateTime.Now;
                uloga.isActive = false;
                uloga.ModifiedAt = null;
                context.SaveChanges();
          
           
        }
    }
}
