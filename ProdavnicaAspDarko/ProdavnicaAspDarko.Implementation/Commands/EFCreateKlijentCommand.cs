using FluentValidation;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Email;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using ProdavnicaAspDarko.Implementation.Functions;
using ProdavnicaAspDarko.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFCreateKlijentCommand : ICreateKlijentCommand
    {
       
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly CreateKlijentValidator _validator;
        private readonly IEmailSender _sender;

        public EFCreateKlijentCommand(ProdavnicaAspDarkoContext context, CreateKlijentValidator validator, IEmailSender sender)
        {
            _context = context;
            _validator = validator;
            _sender = sender;
        }

        public int Id => 1;

        public string Name => "Kreiranje korisnika pomocu EF";
      
        public void Execute(KlijentDto request)
        {
            _validator.ValidateAndThrow(request);
            var klijent = new Klijent
            {
                Jmbg = request.Jmbg,
                Ime = request.Ime,
                Prezime = request.Prezime,
                Email = request.Email,
                Lozinka = KreirajMD5.MD5Hash(request.Lozinka),
                IdUloga = 5
            };
            _context.Klijenti.Add(klijent);
            _context.SaveChanges();

            var idKlijent = klijent.Id;
            var usecase1 = new KlijentUseCase
            {
                KlijentId = idKlijent,
                UseCaseId = 8

            };
            _context.KlijentUseCases.Add(usecase1);
            var usecase2 = new KlijentUseCase
            {
                KlijentId = idKlijent,
                UseCaseId = 10

            };
            _context.KlijentUseCases.Add(usecase2);
            var usecase3 = new KlijentUseCase
            {
                KlijentId = idKlijent,
                UseCaseId = 26

            };
            _context.KlijentUseCases.Add(usecase3);
            _context.SaveChanges();

            _sender.Send(new SendEmailDto
            {
                Content = "<h1>Registracija Za Klijenta Uspesno Odradjena!</h1>",
                SendTo = request.Email,
                Subject = "Registracija"
            }); 
        }
    }
}
