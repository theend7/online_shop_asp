using AutoMapper;
using FluentValidation;
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
    public class EFCreateCenaCommand : ICreateCenaCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly CreateCenaValidator _validator;
        private readonly IMapper _mapper;


        public EFCreateCenaCommand(ProdavnicaAspDarkoContext context, CreateCenaValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 6;

        public string Name => "Kreiranje cene pomocu EF-a";

        public void Execute(CenaDto request)
        {
            _validator.ValidateAndThrow(request);
            var cena = _mapper.Map<Cena>(request);
            _context.Cene.Add(cena);
            _context.SaveChanges();
        }
    }
}
