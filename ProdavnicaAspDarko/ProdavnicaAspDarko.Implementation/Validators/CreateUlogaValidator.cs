using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class CreateUlogaValidator : AbstractValidator<UlogaDto>
    {
        public CreateUlogaValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.NazivUloge).NotEmpty().Must(naziv => !context.Uloge.Any(k => k.NazivUloge == naziv)).WithMessage("Naziv uloge mora biti jedinstven!");
        }
    }
}
