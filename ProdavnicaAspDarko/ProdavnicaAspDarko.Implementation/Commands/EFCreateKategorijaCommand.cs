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
    public class EFCreateKategorijaCommand : ICreateKategorijaCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly CreateKategorijaValidator _validator;
        private readonly IMapper _mapper;

        public EFCreateKategorijaCommand(ProdavnicaAspDarkoContext context, CreateKategorijaValidator validator, IMapper mapper)
        {
            _context = context;
            _validator = validator;
            _mapper = mapper;
        }

        public int Id => 5;

        public string Name => "Kreiranje kategorije pomocu EF-a";

        public void Execute(KategorijaDto request)
        {
            _validator.ValidateAndThrow(request);
            var kategorija = _mapper.Map<Kategorija>(request);
            _context.Kategorije.Add(kategorija);
            _context.SaveChanges();
        }
    }
}
