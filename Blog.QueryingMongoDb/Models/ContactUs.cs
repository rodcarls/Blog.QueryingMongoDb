using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.QueryingMongoDb.Models
{
    public class ContactUsModel
    {
        [BsonId]
        public String Id { get; set; } //MongoDb uses this field as identity.

       // public int Id { get; set; }

        [Required]
        public string NameSurname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Url)]
        public string Website { get; set; }
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}