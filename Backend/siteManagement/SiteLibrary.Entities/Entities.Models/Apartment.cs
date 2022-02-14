using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.Entities.Models
{
    public class Apartment
    {
        //Id aynı zamanda dairenin no sunu verir.
        public int Id { get; set; }
        public int FloorNumber { get; set; }
        //Hangi Id li daire hangi user a ait görebilmek için
        public int UserId { get; set; }
        //Dairenin hangi blokta olduğunu görebilmek için
        public User User { get; set; }
        public int BlockNum { get; set; }
        //Dairenin tipini görebilmek içiin (2+1 vs.)
        public int TypeId { get; set; }
        public ApartmentType ApartmentType { get; set; }
        //user için
        
    }
}
