using System;
using System.Collections.Generic;
using System.Text;

namespace ProdavnicaAspDarko.Domain
{
    public class KlijentUseCase
    {
        public int Id { get; set; }
        public int KlijentId { get; set; }
        public int UseCaseId { get; set; }

        public virtual Klijent Klijent { get; set; }
    }
}
