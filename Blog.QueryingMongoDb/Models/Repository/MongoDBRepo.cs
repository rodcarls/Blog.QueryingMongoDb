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

        public MongoDbRepo(string url, string database)
        {
            this.Client = new MongoClient(url);
            this.Db = this.Client.GetDatabase(database);
        }


    }

}