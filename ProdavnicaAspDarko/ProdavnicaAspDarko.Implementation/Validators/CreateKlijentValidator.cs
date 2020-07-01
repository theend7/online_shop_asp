using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class CreateKlijentValidator : AbstractValidator<KlijentDto>
    {
        public CreateKlijentValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.Jmbg).NotEmpty().Must(jmbg => !context.Klijenti.Any(k => k.Jmbg == jmbg)).WithMessage("Jmbg mora biti jedinstven");
            RuleFor(x => x.Ime).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Prezime).NotEmpty().MinimumLength(3);
            RuleFor(x => x.Email).EmailAddress().NotEmpty().Must(email => !context.Klijenti.Any(k => k.Email == email)).WithMessage("Email mora biti jedinstven");
            RuleFor(x => x.Lozinka).NotEmpty().MinimumLength(5);

        }
    }
}
