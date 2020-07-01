using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Application.Queries;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Queries
{
    public class EFDohvatiSlikeProizvoda : IGetProizvodSlikeQuery
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFDohvatiSlikeProizvoda(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 28;

        public string Name => "Dohvatanje slika oredjenog proizvoda preko EF-a";

        public IEnumerable<ProizvodNjegoveSlikeDto> Execute(int search)
        {
                var upit = context.Slike.Where(x => x.ProizvodId == search);
                var response = upit.Select(x => new ProizvodNjegoveSlikeDto

                {
                    PutanjaSlike = x.SlikaPutanja,
                    IdSlike = x.Id,
                    IdProizvod = x.ProizvodId

                }).ToList();
                return response;
        }
    }
}
