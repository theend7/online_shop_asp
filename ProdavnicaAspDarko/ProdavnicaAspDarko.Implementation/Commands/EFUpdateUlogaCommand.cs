using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Query.Internal;
using ProdavnicaAspDarko.Application.Commands;
using ProdavnicaAspDarko.Application.DataTransfer;
using ProdavnicaAspDarko.Application.Exceptions;
using ProdavnicaAspDarko.Domain;
using ProdavnicaAspDarko.EFDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProdavnicaAspDarko.Implementation.Commands
{
    public class EFUpdateUlogaCommand : IUpdateUlogaCommand
    {
        private readonly ProdavnicaAspDarkoContext context;

        public EFUpdateUlogaCommand(ProdavnicaAspDarkoContext context)
        {
            this.context = context;
        }

        public int Id => 19;

        public string Name => "Update-ovanje uloge pomocu EF-a";

        public void Execute(UlogaUpdateDto request)
        {

                var ulogaId = context.Uloge.Find(request.IdUloga);
                if (ulogaId.NazivUloge == request.NazivUloge)
                {
                    ulogaId.NazivUloge = request.NazivUloge;
                }
                else
                {
                    if (context.Uloge.Any(x => x.NazivUloge == request.NazivUloge))
                    {
                        throw new ConflictException(request.NazivUloge,typeof(Uloga));
                    }
                    else
                    {
                        if (request.NazivUloge == null)
                        {
                            throw new ConflictException(request.NazivUloge, typeof(Uloga));
                        }
                        else
                        {
                            ulogaId.NazivUloge = request.NazivUloge;

                            context.SaveChanges();
                        }
                    }
                }
            
            
          
            


           

           
        }
    }
}
