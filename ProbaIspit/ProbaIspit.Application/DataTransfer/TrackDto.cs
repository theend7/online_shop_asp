using System;
using System.Collections.Generic;
using System.Text;

namespace ProbaIspit.Application.DataTransfer
{
    public class TrackDto
    {
    
        public string Name { get; set; }
        public int AlbumId { get; set; }
        public int MediaTypeId { get; set; }
        public int GenreId { get; set; }
        public string Composer { get; set; }

        public decimal Sekunde { get; set; }
        public decimal Megabajti { get; set; }
        public decimal Cena { get; set; }
    }
}
