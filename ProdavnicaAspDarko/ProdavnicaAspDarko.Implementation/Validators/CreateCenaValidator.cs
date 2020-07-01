using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class CreateCenaValidator : AbstractValidator<CenaDto>
    {
        public CreateCenaValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.CenaP).NotEmpty();
            RuleFor(x => x.ProizvodId).NotEmpty();
        }
    }
}
