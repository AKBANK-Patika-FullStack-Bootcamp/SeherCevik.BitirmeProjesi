using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.Entities.Models
{
    //Bu sınıfında başlangıcta veritabanında dolu verileri gelecek o yüzden controller ı yok.
    public class ApartmentType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        //İlişkisel veritabanı için
        public ICollection<Apartment> Apartments { get; set; }
    }
}
