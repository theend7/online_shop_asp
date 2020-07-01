using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class UpdateEmailValidator : AbstractValidator<KlijentUpdateDto>
    {
        public UpdateEmailValidator(ProdavnicaAspDarkoContext context)
        {
           
            RuleFor(x => x.Email).EmailAddress().NotEmpty().Must(email => !context.Klijenti.Any(k => k.Email == email)).WithMessage("Email koji ste uneli mora biti jedinstven,u bazi vec neko postoji sa unetim email-om");
          
        }
    }
       
}
