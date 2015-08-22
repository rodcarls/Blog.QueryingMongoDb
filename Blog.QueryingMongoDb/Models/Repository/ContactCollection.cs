using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Blog.QueryingMongoDb.Models.Repository
{
    public class ContactCollection
    {
        //Intializes the mongo db repository
        internal MongoDbRepo _repo = new MongoDbRepo("mongodb://127.0.0.1:27017", "QueryMongoDb");
        //Defines the collection name used by project
        private const string _collectionName = "ContactCollection";
        //Contains all documents inside the collection
        public IMongoCollection<ContactModel> Collection;

        //Constructor
        public ContactCollection()
        {
            this.Collection = _repo.Db.GetCollection<ContactModel>(_collectionName);
        }

        /// <summary>
        /// Insert a contract inside the collection
        /// </summary>
        /// <param name="contact">Contract to inser</param>
        public void InsertContact(ContactModel contact)
        {
            this.Collection.InsertOneAsync(contact);
        }
        /// <summary>
        /// Selects all documents
        /// </summary>
        /// <returns>List of all contract</returns>
        public List<ContactModel> SelectAll()
        {
            var query = this.Collection.Find(new BsonDocument()).ToListAsync();
            return query.Result;
        }
        /// <summary>
        /// Get a contract by id
        /// </summary>
        /// <param name="id">id</param>
        /// <returns>returned contracts</returns>
        public ContactModel Get(string id)
        {
            return this.Collection.Find(new BsonDocument { { "_id", new ObjectId(id) } }).FirstAsync().Result;
        }
        /// <summary>
        /// Updates an contract
        /// </summary>
        /// <param name="id">Id of contract to update</param>
        /// <param name="contact">Updated informations</param>
        public void UpdateContact(string id, ContactModel contact)
        {
            contact.Id = new ObjectId(id);

            var filter = Builders<ContactModel>.Filter.Eq(s => s.Id, contact.Id);
            this.Collection.ReplaceOneAsync(filter, contact);
        }
    }
}