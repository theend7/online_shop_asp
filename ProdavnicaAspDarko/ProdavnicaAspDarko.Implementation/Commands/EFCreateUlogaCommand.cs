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
    public class EFCreateUlogaCommand : ICreateUlogaCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly CreateUlogaValidator _validator;
        private readonly IMapper _mapper;

        public EFCreateUlogaCommand(ProdavnicaAspDarkoContext context, CreateUlogaValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 4;

        public string Name => "Kreiranje Uloge pomoce EF-a";

        public void Execute(UlogaDto request)
        {
            _validator.ValidateAndThrow(request);
            var uloga = _mapper.Map<Uloga>(request);
            _context.Uloge.Add(uloga);
            _context.SaveChanges();
        }
    }
}
