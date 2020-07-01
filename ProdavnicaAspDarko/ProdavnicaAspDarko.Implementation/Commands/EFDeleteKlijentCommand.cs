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
    public class EFDeleteKlijentCommand : IDeleteKlijentCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        public EFDeleteKlijentCommand(ProdavnicaAspDarkoContext context)
        {
            _context = context;
        }
        public int Id => 2;

        public string Name => "Brisanje klijenta";

        public void Execute(int request)
        {
                var klijent = _context.Klijenti.Find(request);
                if (klijent == null)
                {
                    throw new EntityNotFoundException(request, typeof(Klijent));
                }
                var upitZaUseCaseDeleteKorisnik = _context.KlijentUseCases.Where(x => x.KlijentId == request).AsQueryable();
                foreach (var k in upitZaUseCaseDeleteKorisnik)
                {
                    _context.Remove(k);
                }
                _context.SaveChanges();

                var upitZaPorudzbine = _context.Porudzbine.Where(x => x.KlijentId == request).AsQueryable();
                foreach (var k in upitZaPorudzbine)
                {
                    if (k.PorudzbinaStatus != PorudzbinaStatus.Isporucena || k.PorudzbinaStatus != PorudzbinaStatus.Poslata)
                    {
                        k.PorudzbinaStatus = PorudzbinaStatus.Otkazana;
                    }

                }
                _context.SaveChanges();
                klijent.isDeleted = true;
                klijent.DeletedAt = DateTime.Now;
                klijent.isActive = false;
                klijent.ModifiedAt = null;
                _context.SaveChanges();
         
             

        }
    }
}
