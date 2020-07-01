using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFUpdateKategorijaCommand : IUpdateKategorijaCommand
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFUpdateKategorijaCommand(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id =>23;

        public string Name => "Update-ovanje kategorije pomocu EF-a";

        public void Execute(KategorijaUpdateDto request)
        {
                var kategorijaId = context.Kategorije.Find(request.IdKategorija);
                if (kategorijaId.NazivKategorije == request.NazivKategorije)
                {
                    kategorijaId.NazivKategorije = request.NazivKategorije;
                }
                else
                {
                    if (context.Kategorije.Any(x => x.NazivKategorije == request.NazivKategorije))
                    {
                        throw new ConflictException(request.NazivKategorije, typeof(Kategorija));
                    }
                    else
                    {
                        if(request.NazivKategorije == null)
                        {
                            throw new ConflictException(request.NazivKategorije, typeof(Kategorija)); 
                        }
                        else
                        {
                            kategorijaId.NazivKategorije = request.NazivKategorije;

                            context.SaveChanges();
                        }
                    }
                }
        }
    }
}
