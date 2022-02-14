using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.Entities.Models
{
    //Bu sınıfta başlangıçta sadece adminin verileri dolu olacak ki userlardan hangisinin yönetici olduğu belli olsun .
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string SurName { get; set; }
        public string TcNo { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }

        //aracı var mı varsa plako no,Eğer plako no yazılmamışsa değer null gelecek yani arabası olmadığı buradan anlaşılacak.
        public string VehiclePlate { get; set; }

        public int RoleId { get; set; }
        public Role Role { get; set; }
        //ilişkisel veritabanı için; user sınıfında apatmentınformation sınıfını tanımlarız

        //public int ApartmentId { get; set; }
        //public Apartment Apartment { get; set; }

        //Bir userın birden fazla mesajı olabilir ama bir messajın bir tane user ı var.O yüğzden buraya liste yaptık . message sınıfında da prop User User yaptık.
        public ICollection<Message> Messages { get; set; }
    }
}
