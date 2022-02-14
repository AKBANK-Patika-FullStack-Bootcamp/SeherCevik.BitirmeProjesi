using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.DTO
{
    //DTO nedir; data transfer object data transferi için kullanılan sadece transfer data aktarımı yapmak için oluşturduğumuz sınıflardır. Entitilerimizn karşılığu normal programlamada direkt olarak veritabanında oluşacak tablolarımızın karışılığıdır.Tablolar= entitiy sınıfları . veritabanımızda entitimizi code first yapmak ıd otomarik artan olsun ama entiti de ıd alanı var controller de entiti class ının aynısını parametre olarak alırsak burada normalde bizim atamadığımız ıd değeri de kullanıcıdan beklenecektir. veyahut kullanıcının atmayacağı bizim default olarak tanımlayacağımız alanlar olabiliri.bu alanları içermeyen ıd veya kullanıcıdan almıcamız verileri içermeyen diğer kısımları entiti ile birebir aynı olan sınıflara DTO denir. Bu sadece kullanıcıdan programımıza veri alırken sadece ihtiyacıomız olan verileri almak üzere entitimizden  ihtiyaçımız olmayan kısımları çıkararak oluşturduğumuz sınıflardır.

    //ıd veya kullanıcıdan almıcamız verileri içermeyen diğer kısımları entiti ile birebir aynı olan sınıflara DTO denir.Bu sadece kullanıcıdan programımıza veri alırken sadece ihtiyacıomız olan verileri almak üzere entitimizden  ihtiyaçımız olmayan kısımları çıkararak oluşturduğumuz sınıflardır.
    public class UserDTO
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string TcNo { get; set; }
        public string TelNumber { get; set; }
        public string Email { get; set; }
    }
}
