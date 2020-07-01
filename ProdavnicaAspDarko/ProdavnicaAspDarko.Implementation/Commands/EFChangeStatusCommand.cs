using Microsoft.EntityFrameworkCore;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
   
    
    public class EFChangeStatusCommand : ICreateChangeStatusCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;

        public EFChangeStatusCommand(ProdavnicaAspDarkoContext context)
        {
            _context = context;
        }

        public int Id => 9;

        public string Name => "Kreiranje Statusa porudzbine putem Ef-a";

        public void Execute(CreateChangeStatusPorudzbineDto request)
        {
            var porudzbina = _context.Porudzbine.Include(x => x.DetaljiPorudzbina).ThenInclude(x => x.Proizvod)
                .FirstOrDefault(x => x.Id == request.IdPorudzbina);

            if(porudzbina == null)
            {

            }
            if(porudzbina.PorudzbinaStatus == PorudzbinaStatus.Primljena)
            {

            }
            if(porudzbina.PorudzbinaStatus == PorudzbinaStatus.Primljena || porudzbina.PorudzbinaStatus == PorudzbinaStatus.Isporucena)
            {
                if(request.Status == PorudzbinaStatus.Otkazana || request.Status == PorudzbinaStatus.Isporucena)
                {
                    porudzbina.PorudzbinaStatus = request.Status;
                    if(request.Status == PorudzbinaStatus.Otkazana)
                    {
                        foreach(var p in porudzbina.DetaljiPorudzbina)
                        {
                            p.Proizvod.KolicinaProizvoda += p.Kolicina;
                        }
                    }
                    _context.SaveChanges();
                }
            }
        }
    }
}
