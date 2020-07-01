using FluentValidation;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
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
    public class EFUpdateKlijentCommand : IUpdateKlijentCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly UpdateKlijentValidator _validator;
        private readonly UpdateEmailValidator _ulogaEmailValidator;
        private readonly DaLiPostojiUlogaUbaziValidator _ulogaIdValidator;


        public EFUpdateKlijentCommand(ProdavnicaAspDarkoContext context, UpdateKlijentValidator validator, UpdateEmailValidator ulogaEmailValidator, DaLiPostojiUlogaUbaziValidator ulogaIdValidator)
        {
            _context = context;
            _validator = validator;
            _ulogaEmailValidator = ulogaEmailValidator;
            _ulogaIdValidator = ulogaIdValidator;
        }

        public int Id => 15;

        public string Name => "Update-ovanje Klijenta pomocu EF-a";

        public void Execute(KlijentUpdateDto request)
        {
           
           var klijentId = _context.Klijenti.Find(request.IdKlijentUpdate);

            _ulogaIdValidator.ValidateAndThrow(request);
            _validator.ValidateAndThrow(request);

                if (klijentId.Email == request.Email)
                {

                    klijentId.Ime = request.Ime;
                    klijentId.Prezime = request.Prezime;
                    klijentId.Email = request.Email;
                    klijentId.Lozinka = KreirajMD5.MD5Hash(request.Lozinka);
                    klijentId.IdUloga = request.IdUloga;

                    _context.SaveChanges();
                }
                else
                {
                    if (_context.Klijenti.Any(x => x.Email == request.Email))
                    {
                        _ulogaEmailValidator.ValidateAndThrow(request);
                    }
                    else
                    {
                        klijentId.Ime = request.Ime;
                        klijentId.Prezime = request.Prezime;
                        klijentId.Email = request.Email;
                        klijentId.Lozinka = KreirajMD5.MD5Hash(request.Lozinka);
                        klijentId.IdUloga = request.IdUloga;

                        _context.SaveChanges();
                    }
                }
        }
    }
}
