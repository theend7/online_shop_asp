using System;
using System.Collections.Generic;
using System.Text;

namespace ProbaIspit.Application.DataTransfer
{
    public class InvoiceDto
    {
        public int Id { get; set; }
        public string ImeKupca { get; set; }
        public string PrezimeKupca { get; set; }

        public string EmailKupca { get; set; }

        public string TelefonKupca { get; set; }
        public string BilingAdresa { get; set; }
        public string BilingGrad { get; set; }
        public string BilingDrzava { get; set; }
        public string BilingZemlja { get; set; }
        public string BilingPostanskiKod { get; set; }

        public ICollection<InvoiceLineDto> StavkeFakture { get; set; }
    }
    public class InvoiceLineDto
    {
        public int Id { get; set; }
        public string NazivPesme { get; set; }
        public decimal Cena { get; set; }

        public int Kolicina { get; set; }
    }
}
