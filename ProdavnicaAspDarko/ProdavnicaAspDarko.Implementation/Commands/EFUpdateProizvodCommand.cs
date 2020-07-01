using FluentValidation;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using ProdavnicaAspDarko.Implementation.Functions;
using ProdavnicaAspDarko.Implementation.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFUpdateProizvodCommand : IUpdateProizvodCommand
    {
        private readonly ProdavnicaAspDarkoContext _context;
        private readonly UpdateProizvodValidator _validator;
        public EFUpdateProizvodCommand(ProdavnicaAspDarkoContext context, UpdateProizvodValidator validator)
        {
            _context = context;
            _validator = validator;
        }

        public int Id => 27;

        public string Name => "Update-ovanje proizvoda pomocu EF-a";

        public void Execute(ProizvodUpdateDto request)
        {
                _validator.ValidateAndThrow(request);
                var proizvodId = _context.Proizvodi.Find(request.IdProizvoda);
                if (proizvodId.NazivProizvoda == request.NazivProizvoda)
                {
                    proizvodId.NazivProizvoda = request.NazivProizvoda;
                    proizvodId.OpisProizvoda = request.OpisProizvoda;
                    proizvodId.SlikaProizvoda = UbaciSlikuZaUpdateProizvoda.UbaciSlikuUpdate(request.Slika);
                    proizvodId.KolicinaProizvoda = request.Kolicina;
                    _context.SaveChanges();
                    var cena = new Cena
                    {
                        CenaP = request.Cena,
                        ProizvodId = request.IdProizvoda,
                    };
                    _context.Cene.Add(cena);
                    _context.SaveChanges();
                }
                else
                {
                    if (_context.Proizvodi.Any(x => x.NazivProizvoda == request.NazivProizvoda))
                    {
                        throw new ConflictException(request.NazivProizvoda, typeof(Proizvod));
                    }
                    else
                    {
                        proizvodId.NazivProizvoda = request.NazivProizvoda;
                        proizvodId.OpisProizvoda = request.OpisProizvoda;
                        proizvodId.SlikaProizvoda = UbaciSlikuZaUpdateProizvoda.UbaciSlikuUpdate(request.Slika);
                        proizvodId.KolicinaProizvoda = request.Kolicina;
                        _context.SaveChanges();
                        var cena = new Cena
                        {
                            CenaP = request.Cena,
                            ProizvodId = request.IdProizvoda,

                        };
                        _context.Cene.Add(cena);
                        _context.SaveChanges();
                    }
                }
         
              
        }
    }
}
