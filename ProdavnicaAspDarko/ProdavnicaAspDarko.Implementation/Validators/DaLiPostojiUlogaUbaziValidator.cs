using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class DaLiPostojiUlogaUbaziValidator : AbstractValidator<KlijentUpdateDto>
    {
        public DaLiPostojiUlogaUbaziValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.IdUloga).Must(idUloga => context.Uloge.Any(k => k.Id == idUloga)).WithMessage("ID uloge koji ste uneli mora postojati u bazi,uneti id-uloge ne posotji u bazi");
        }
       
    }
}
