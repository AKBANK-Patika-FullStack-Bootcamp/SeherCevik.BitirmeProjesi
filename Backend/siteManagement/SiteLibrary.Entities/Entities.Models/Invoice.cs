using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.Entities.Models
{
    public class Invoice
    {
        public int Id { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal PaidPrice { get; set; }
        public decimal Debt { get; set; }

        //İlişkisel veritabanı için
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; }

        public int InvoiceTypeId { get; set; }
        public InvoiceType InvoiceType { get; set; }

        //public int ElektrikFaturasi { get; set; }
        //public int DogalgazFaturasi { get; set; }
        //public int SuFaturasi { get; set; }
        //public int Aidat { get; set; }
    }
}
