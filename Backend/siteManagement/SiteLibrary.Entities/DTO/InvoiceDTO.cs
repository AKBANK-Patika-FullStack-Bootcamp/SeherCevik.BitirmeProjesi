using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.DTO
{
    public class InvoiceDTO
    {
        public decimal TotalPrice { get; set; }
        public decimal PaidPrice { get; set; }
        public decimal Debt { get; set; }
    }
}
