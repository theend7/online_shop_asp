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
    public class CreateKategorijaValidator :AbstractValidator<KategorijaDto>
    {
        public CreateKategorijaValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.NazivKategorije).NotEmpty().Must(naziv => !context.Kategorije.Any(k => k.NazivKategorije == naziv)).WithMessage("Naziv kategorije proizvoda mora biti jedinstven!");
        }

    }
}
