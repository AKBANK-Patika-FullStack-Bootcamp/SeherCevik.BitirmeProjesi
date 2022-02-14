using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.Entities.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public int UserId { get; set; }
        //İlişkisel veritabanı için
        public User User { get; set; }
        public bool Seen { get; set; }
    }
}
