using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.Entities.Models
{
    //Bu sınıf veritabanında sabit tutulacak yani program başladığında veritabanında hazır veriler dolu olacak . Bu yüzden controllerı olmayacak .
    public class Role
    {
        public int Id { get; set; }
        public string Name { get; set; }

        //ilişikisel veritabanı için
        public ICollection<User> Users { get; set; }

    }
}
