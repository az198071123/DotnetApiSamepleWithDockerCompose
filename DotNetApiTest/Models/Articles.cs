using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DotNetApiTest.Models
{
    [BsonIgnoreExtraElements]
    public class Articles
    {
        [BsonId]
        // [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }


        [BsonElement("_cls")]
        public string Cls { get; set; }


        [BsonElement("article_title")]
        public string Title { get; set; }

        [BsonElement("author")]
        public string Author { get; set; }

        [BsonElement("board")]
        public string Board { get; set; }

        [BsonElement("content")]
        public string Content { get; set; }

        [BsonElement("date")]
        public string Date { get; set; }

        [BsonElement("ip")]
        public string Ip { get; set; }

        // [BsonElement("message_count")]
        // public string MessageCount { get; set; }

        // [BsonElement("messages")]
        // public string Messages { get; set; }

        [BsonElement("created_at")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime CreatedAt { get; set; }

        [BsonElement("updated_at")]
        [BsonDateTimeOptions(Kind = DateTimeKind.Local)]
        public DateTime UpdatedAt { get; set; }

    }

}
