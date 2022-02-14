using MongoDB.Driver;
using SiteLibrary.Entities.Entities.Models;
using siteManagement.Settings;

namespace siteManagement.Service
{
    public class CreditCardService
    {
        private IDbSettings _settings;
        private IMongoCollection<CreditCard> _CreditCard;

        public CreditCardService(IDbSettings settings)
        {
            _settings = settings;
            MongoClient client = new MongoClient(settings.ConnectionString);
            var db = client.GetDatabase(settings.Database);
            _CreditCard = db.GetCollection<CreditCard>(settings.Collection);
        }


        //Tümünü Listeleme
        public List<CreditCard> GetAll()
        {
            return _CreditCard.Find(u => true).ToList();
        }

        //Tek bir kullanıcı getirme
        public CreditCard GetSingle(int id)
        {
            return _CreditCard.Find(u => u.Id == id).FirstOrDefault();
        }

        //Kullanıcı ekleme
        public CreditCard Add(CreditCard user)
        {
            _CreditCard.InsertOne(user);
            return user;
        }

        //Kullanıcı güncelleme
        public long Update(CreditCard creditCard)
        {
            return _CreditCard.ReplaceOne(u => u.Id == creditCard.Id, creditCard).ModifiedCount;
        }

        //Kullanıcı silme
        public long Delete(int id)
        {
            return _CreditCard.DeleteOne(u => u.Id == id).DeletedCount;
        }

    }
}

