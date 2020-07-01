using FluentValidation;
using Microsoft.EntityFrameworkCore.Internal;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Validators
{
    public class CreateDetaljiPorudzbineValidator : AbstractValidator<CreateDetaljiPorudzbineDto>
    {
        private readonly ProdavnicaAspDarkoContext context;
        public CreateDetaljiPorudzbineValidator(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
            
            RuleFor(x => x.ProizvodId).Must(ProizvodPostoji).WithMessage("Proizvod sa id ne postoji")
                .DependentRules(()=> {
                    RuleFor(x => x.Kolicina).GreaterThan(0).WithMessage("Kolicina mora biti veca od 0")
                    .Must(KolicinaProizvodaNePrelaziKolicinu).WithMessage("Definisana kolicina koja je prosledjena je nedostupna");
                    RuleFor(c => c.IdCena).Must(IdCene).WithMessage("Id cene za zadati proizvod ne postoji");

                });

        }
        private bool IdCene(int IdCena)
        {
            return context.Cene.Any(x => x.Id == IdCena);
        }
        private bool ProizvodPostoji(int proizvodId)
        {
            return context.Proizvodi.Any(x => x.Id == proizvodId);
        }
        private bool KolicinaProizvodaNePrelaziKolicinu(CreateDetaljiPorudzbineDto dto, int kolicina)
        {
            return context.Proizvodi.Find(dto.ProizvodId).KolicinaProizvoda >= kolicina;
        }


    }
}
