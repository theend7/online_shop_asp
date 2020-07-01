using AutoMapper;
using FluentValidation;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using ProdavnicaAspDarko.Implementation.Functions;
using ProdavnicaAspDarko.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFCreateSlikaCommand : ICreateSlikaCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly CreateSlikaValidator _validator;
        

        public EFCreateSlikaCommand(ProdavnicaAspDarkoContext context, CreateSlikaValidator validator)
        {
            _context = context;
            _validator = validator;
          
        }

        public int Id => 7;

        public string Name => "Kreiranje Slike pomocu EF-a";

        public void Execute(SlikaDto request)
        {
                var putanje = UbaciSlike.UbaciSlikeProizvoda(request.SlikeProizvoda);
                _validator.ValidateAndThrow(request);
                for (int s = 0; s < putanje.Count; s++)
                {
                    var slikaProizvoda = new Slika
                    {
                        SlikaPutanja = putanje[s],
                        ProizvodId = request.IdProizvod
                    };
                    _context.Slike.Add(slikaProizvoda);
                }
                _context.SaveChanges();
        }
    }
}
