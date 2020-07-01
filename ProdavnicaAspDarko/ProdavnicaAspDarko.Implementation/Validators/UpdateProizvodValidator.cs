using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class UpdateProizvodValidator : AbstractValidator<ProizvodUpdateDto>
    {
        public UpdateProizvodValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.NazivProizvoda).NotEmpty();
            RuleFor(x => x.OpisProizvoda).NotEmpty();
            RuleFor(x => x.Cena).NotEmpty();
            RuleFor(x => x.Kolicina).NotEmpty();
            RuleFor(x => x.Slika).NotEmpty();
           
        }
    }
}
