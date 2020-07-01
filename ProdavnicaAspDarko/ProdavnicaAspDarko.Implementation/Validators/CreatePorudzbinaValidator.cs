using FluentValidation;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class CreatePorudzbinaValidator :  AbstractValidator<CreatePorudzbinaDto>
    {
       
        public CreatePorudzbinaValidator(ProdavnicaAspDarkoContext context)
        {
            RuleFor(x => x.PorudzbinaDatum).GreaterThan(DateTime.Today).WithMessage("Datum porudzbine mora biti u buducnosti")
                .LessThan(DateTime.Now.AddDays(30))
                .WithMessage("Datum porudzbine ne moze biti vise od 30 dana od danas");
            RuleFor(x => x.Adresa).NotEmpty().WithMessage("Adresa je obavezna");

            RuleFor(x => x.Items).NotEmpty().WithMessage("Mora biti bar jedna porudzbina da bi  se kreirala porudzbina")
                .Must(x=>x.Select(x=>x.ProizvodId).Distinct().Count() == x.Count()).WithMessage("Dupliranje proizvoda nije dozvoljeno")
                .DependentRules(()=> {
                    RuleForEach(x => x.Items).SetValidator(new CreateDetaljiPorudzbineValidator(context));
                });
           
        }
    }
}
