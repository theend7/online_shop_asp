using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class CreateSlikaValidator : AbstractValidator<SlikaDto>
    {
        public CreateSlikaValidator(ProdavnicaAspDarkoContext context)
        {
            RuleForEach(x => x.SlikeProizvoda).NotEmpty();
        }
    }
}
