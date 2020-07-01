using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFDeleteSlikeProizvodaCommand : IDeleteSlikeProizvodaCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;

        public EFDeleteSlikeProizvodaCommand(ProdavnicaAspDarkoContext context)
        {
            _context = context;
        }

        public int Id => 29;

        public string Name => "Brisanje slika odredjenih proizvoda pomocu EF-a";

        public void Execute(IEnumerable<ProizvodNjegoveSlikeDto> request)
        {

            var upit = _context.Slike;
            foreach(var s in request)
            {
                var idSlike = upit.Find(s.IdSlike);
                idSlike.isDeleted = true;
                idSlike.DeletedAt = DateTime.Now;
                idSlike.isActive = false;
                idSlike.ModifiedAt = null;

            }
            _context.SaveChanges();

            






        }
    }
}
