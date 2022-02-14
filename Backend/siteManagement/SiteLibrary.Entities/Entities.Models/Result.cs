using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.Entities.Models
{
    public class Result<T>
    {
        //Bir tane değişken tipli result sınıfı tanımlayıp bütün classlarımız için kullanabiliriz.
        // veri dönerken ; büyüktür küçüktür işaretleri arasına yazdığımız türden bir liste olacak (result ın içinde)
        public bool Status { get; set; }
        public string? message { get; set; }
        public T Data { get; set; }
    }
}
