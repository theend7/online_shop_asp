using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class UpdateKlijentValidator :  AbstractValidator<KlijentUpdateDto>
    {
        public UpdateKlijentValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.IdKlijentUpdate).Must(idKlijent => context.Klijenti.Any(k => k.Id == idKlijent)).WithMessage("ID klijenta koji ste uneli mora postojati u bazi,uneti id-klijenta ne posotji u bazi");
            RuleFor(x => x.Ime).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Prezime).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Email).EmailAddress().NotEmpty();
            RuleFor(x => x.Lozinka).NotEmpty();
            RuleFor(x => x.IdUloga).NotEmpty();
             
        }
    }
}
