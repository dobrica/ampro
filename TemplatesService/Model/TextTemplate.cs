using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class TextTemplate
{
    [BsonElement("_id")]
    public ObjectId ObjectId { get; set; }
    [BsonElement("primaryId")]
    public int PrimaryId { get; set; }
    [BsonElement("body")]
    public string Body { get; set; } = String.Empty;
}