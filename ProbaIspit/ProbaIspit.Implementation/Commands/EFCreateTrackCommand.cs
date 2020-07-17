using ProbaIspit.Application.Commands;
using ProbaIspit.Application.DataTransfer;
using ProbaIspit.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProbaIspit.Implementation.Commands
{
    public class EFCreateTrackCommand : ICreateTrackCommand
    {
        private readonly ChinookContext context;

        public EFCreateTrackCommand(ChinookContext context)
        {
            this.context = context;
        }

        public int Id => 2;

        public string Opis =>"Kreiranje pesme pomocu EF-a";

        public void Execute(TrackDto request)
        {
            var lastId = context.Track.OrderByDescending(x => x.TrackId).FirstOrDefault().TrackId;
            var track = new Track
            {
                TrackId = lastId + 1,
                Name = request.Name,
                AlbumId = request.AlbumId,
                MediaTypeId = request.MediaTypeId,
                GenreId = request.GenreId,
                Composer = request.Composer,
                Milliseconds = (int)request.Sekunde * 1000,
                Bytes = (int)request.Megabajti * 1024 * 1024,
                UnitPrice = request.Cena



            };
            context.Track.Add(track);
            context.SaveChanges();
        }
    }
}
