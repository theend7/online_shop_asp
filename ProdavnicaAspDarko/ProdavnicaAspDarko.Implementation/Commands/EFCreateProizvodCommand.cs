using AutoMapper;
using FluentValidation;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using ProdavnicaAspDarko.Implementation.Functions;
using ProdavnicaAspDarko.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFCreateProizvodCommand : ICreateProizvodCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly CreateProizvodValidator _validator;
        private readonly IMapper _mapper;

        public EFCreateProizvodCommand(ProdavnicaAspDarkoContext context, CreateProizvodValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 3;

        public string Name => "Kreiranje proizvoda pomocu EF";

        public void Execute(ProizvodSlikaCenaDto request)
        {
            _validator.ValidateAndThrow(request);
            var putanje = UbaciSlike.UbaciSlikeProizvoda(request.SlikeP);
            var proizvod = new Proizvod
            {
                NazivProizvoda = request.NazivP,
                OpisProizvoda = request.OpisP,
                KolicinaProizvoda = request.KolicinaP,
                SlikaProizvoda = putanje[0],
                IdKategorija = request.IdKategorija
            };
            _context.Proizvodi.Add(proizvod);
            _context.SaveChanges();

            int idProizvodaPoslednjiUnet = proizvod.Id;
            for (int p = 1; p < putanje.Count; p++)
            {
                var slika = new Slika
                {
                    SlikaPutanja = putanje[p],
                    ProizvodId = idProizvodaPoslednjiUnet
                };
                _context.Slike.Add(slika);
            }
            _context.SaveChanges();

            var cena = new Cena
            {
                CenaP = request.CenaP,
                ProizvodId  = idProizvodaPoslednjiUnet

            };
            _context.Cene.Add(cena);
            _context.SaveChanges();

        }
    }
}
