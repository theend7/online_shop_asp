using ProbaIspit.Application.DataTransfer;
using ProbaIspit.Application.Searches;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProbaIspit.Application.Queries
{
    public interface IQueryInvoiceSearch : IQuery<InvoiceSearch,PagedResponse<InvoiceDto>>
    {
    }
}
