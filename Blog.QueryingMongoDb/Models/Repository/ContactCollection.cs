using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Blog.QueryingMongoDb.Models.Repository
{
    public class ContactCollection
    {

        private MongoDbRepo _repo = new MongoDbRepo("mongodb://127.0.0.1:27017", "QueryMongoDb");

        private string _collectionName = "ContactCollection";

        public IMongoCollection<ContactModel> Collection;
 

        public ContactCollection()
        {
            this.Collection = _repo.Db.GetCollection<ContactModel>(this._collectionName);
        }


        public void InsertContact(ContactModel contact)
        {
            this.Collection.InsertOneAsync(contact);
        }

        public List<ContactModel> SelectAll()
        {
            var query = this.Collection.Find(new BsonDocument()).ToListAsync();
            return  query.Result;
        }

        public ContactModel Get(string id)
        {
            return this.Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
        }

        public void UpdateContact(string id, ContactModel contact)
        {
            contact.Id = new ObjectId(id);

            var filter = Builders<ContactModel>.Filter.Eq(s => s.Id, contact.Id);
            this.Collection.ReplaceOneAsync(filter, contact);
        }
    }
}