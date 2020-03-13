using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class Book
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
       
        [BsonElement("Name")]
        [Required]
        public string Name { get; set; }

        [BsonElement("Author")]
        public string Author { get; set; }

        [BsonElement("ISBN")]
        public string ISBN {get; set;}
    }
}