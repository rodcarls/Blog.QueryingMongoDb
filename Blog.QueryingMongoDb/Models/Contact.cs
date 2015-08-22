using MongoDB.Bson;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Blog.QueryingMongoDb.Models
{
    public class ContactModel
    {
        [BsonId]
        public ObjectId Id { get; set; } //MongoDb uses this field as identity.
        [Required]
        [Display(Name = "Name")]
        public string NameSurname { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [DataType(DataType.Url)]
        public string Website { get; set; }
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }
    }
}