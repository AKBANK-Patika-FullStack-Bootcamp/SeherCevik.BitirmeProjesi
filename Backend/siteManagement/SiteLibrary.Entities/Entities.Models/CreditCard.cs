using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SiteLibrary.Entities.Entities.Models
{
    public class CreditCard
    {
        [BsonId] // Id'kolonumuzu tanımlıyor.
        [BsonRepresentation(BsonType.ObjectId)] //Property'imizin tipini belirtiyoruz.
        public int Id { get; set; }

        //BsonElement -> Collection'umuzda karşılık gelen kolon adını temsil ediyor.

        [BsonElement("firstName")]
        public string FirstName { get; set; }

        [BsonElement("lastName")]
        public string LastName { get; set; }

        [BsonElement("cardnumber")]
        public int CardNumber { get; set; }

        [BsonElement("expirationdate")]
        public DateTime ExpirationDate { get; set; }

        [BsonElement("securitycode")]
        public int SecurityCode { get; set; }

        [BsonElement("userid")]
        public int UserId { get; set; }

    }
}

