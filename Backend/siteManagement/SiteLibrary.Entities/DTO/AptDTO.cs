using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.DTO
{
    //AutoMapper, projemizde Entity nesnelerini database’den çektiğimiz haliyle değil, bu nesneleri istediğimiz(UI’da bizim için gerekli olacak) formata çevirmemizi sağlayan basit bir kütüphanedir.DTO(Data Transfer Object) ise AutoMapper’ın dönüştürmesini istediğimiz format modelidir.
    //Senaryomuzda şöyle devam edelim; biz database’den çektiğimiz dataları UI’da bir DataTable içerisinde listelemek istiyoruz fakat bize sadece dataların(Name-Surname),(Department Name),(Age) bölümleri lazım.Bunun için bir DTO(Data Transfer Object) kullanmamız gerekiyor.

    /// <summary>
    /// Kullanıcının girmesi gereken şeyler dto da olur
    /// 
    /// </summary>
    public class AptDTO
    {
        public int FloorNumber { get; set; }
        public int UserId { get; set; }
        public int BlockNum { get; set; }

    }
}
