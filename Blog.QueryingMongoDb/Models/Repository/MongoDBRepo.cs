using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Compilation;
using MongoDB.Driver;
using MongoDB.Driver.Core;
using MongoDB.Bson;
using MongoDB.Driver.Linq;
using MongoDB.Bson.Serialization;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Blog.QueryingMongoDb.Models.Repository
{

    public class MongoDbRepo
    {

        public MongoClient Client;

        public IMongoDatabase Db;

        public IMongoCollection<ContactUsModel> ContactUsCollection;
 
        
        
        public  MongoDbRepo(string url, string database, string collection)
        {

            //BsonClassMap.RegisterClassMap<ContactUsModel>();

            this.Client= new MongoClient(url);
            this.Db = this.Client.GetDatabase(database);
            this.ContactUsCollection = this.Db.GetCollection<ContactUsModel>(collection);
        }



        public async Task<List<ContactUsModel>> SearchFor(Expression<Func<ContactUsModel, bool>> predicate)
        {
            return await this.ContactUsCollection.Find(Builders<ContactUsModel>.Filter.Where(predicate)).ToListAsync();
        }
      
    
    }

}