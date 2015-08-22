using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Blog.QueryingMongoDb.Models;
using Blog.QueryingMongoDb.Models.Repository;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;

namespace Blog.QueryingMongoDb.Controllers
{
    public class ContactUsController : Controller
    {

        public MongoDbRepo Repo= new MongoDbRepo("mongodb://127.0.0.1:27017", "QueryMongoDb", "ContactUs");
        //
        // GET: /ContactUs/

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ContactUsModel contact)
        {
            Repo.ContactUsCollection.InsertOneAsync(contact);
            return View();
        }

        public ActionResult List()
        {
            var query = Repo.ContactUsCollection.Find(new BsonDocument()).ToListAsync();

            return View(query.Result);
        }



   
        public ActionResult Edit(string  contactId)
        {
            var query = Repo.ContactUsCollection.Find(new BsonDocument { { "Id", contactId } }).FirstAsync();
            return View(query.Result);
        }

        //[HttpPost]
        //public ActionResult Edit(ContactUsModel contact)
        //{
        //    //var id = new ObjectId(contact.ToString());
        //    //var filter = Builders<ContactUsModel>.Filter.Eq(s => s._id, id);
        //    //var result =  Repo.ContactUsCollection.ReplaceOneAsync(filter, contact);

        //    //var query = Repo.ContactUsCollection.Find(new BsonDocument()).ToListAsync();

        //    //return View("List", query.Result);
        //}

        
    }
}
