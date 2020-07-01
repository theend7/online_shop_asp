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
    public class CreateProizvodValidator : AbstractValidator<ProizvodSlikaCenaDto>
    {
        public CreateProizvodValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.NazivP).NotEmpty().Must(naziv => !context.Proizvodi.Any(k => k.NazivProizvoda == naziv)).WithMessage("Naziv proizvoda mora biti jedinstven!");
            RuleFor(x => x.OpisP).NotEmpty();
            RuleFor(x => x.CenaP).NotEmpty();
            RuleFor(x => x.KolicinaP).NotEmpty();
            RuleFor(x => x.IdKategorija).NotEmpty();
            RuleForEach(x => x.SlikeP).NotEmpty();
        }
    }
}
