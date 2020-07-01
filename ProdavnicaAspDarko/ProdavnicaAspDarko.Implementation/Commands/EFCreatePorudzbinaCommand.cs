using FluentValidation;
using ProdavnicaAspDarko.Application;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using ProdavnicaAspDarko.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFCreatePorudzbinaCommand : ICreatePorudzbinaCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly CreatePorudzbinaValidator _validator;
        private readonly IApplicationActor _actor;

        public EFCreatePorudzbinaCommand(ProdavnicaAspDarkoContext context, CreatePorudzbinaValidator validator, IApplicationActor actor)
        {
            _context = context;
            _validator = validator;
            _actor = actor;
        }

        public int Id => 8;

        public string Name => "Kreiranje Porudzbine putem EF-a";

        public void Execute(CreatePorudzbinaDto request)
        {
            _validator.ValidateAndThrow(request);
            int idKlijent = _actor.Id;
            var porudzbina = new Porudzbina
            {
                DatumPorudzbine = request.PorudzbinaDatum,
                KlijentId = idKlijent,
                Adresa = request.Adresa

            };
            foreach(var i in request.Items)
            {
                var cena = _context.Cene.Find(i.IdCena);
                var proizvod = _context.Proizvodi.Find(i.ProizvodId);
                var konacnaCenaProizvoda = cena.CenaP;
                proizvod.KolicinaProizvoda -= i.Kolicina;
                porudzbina.DetaljiPorudzbina.Add(new DetaljiPorudzbine
                {
                    Naziv = proizvod.NazivProizvoda,
                    Kolicina = i.Kolicina,
                    Cena = konacnaCenaProizvoda,
                    ProizvodId = i.ProizvodId
                });
                _context.Porudzbine.Add(porudzbina);
                _context.SaveChanges();
            }
        }
    }
}
