using ProbaIspit.Application.Commands;
using ProbaIspit.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ProbaIspit.Implementation.Commands
{
    public class EFDeletePlayListCommand : IDeletePlayListCommand
    {
        private readonly ChinookContext context;

        public EFDeletePlayListCommand(ChinookContext context)
        {
            this.context = context;
        }

        public int Id =>3;

        public string Opis => "Brisanje play liste pomocu EF-a";

        public void Execute(int request)
        {
            var playLista = context.PlaylistTrack.Count(x => x.PlaylistId == request);
            if(playLista == 0)
            {
                var playListaFind = context.Playlist.Find(request);
                context.Playlist.Remove(playListaFind);
                context.SaveChanges();
            }
            else
            {
                throw new ArgumentException("Ne moze se obrisati playlista jer u njoj postoje pesme");
            }
        }
    }
}
