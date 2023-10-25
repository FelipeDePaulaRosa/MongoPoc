using MongoDB.Bson;
using System.Text.Json.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Mongo.POC.Models;

public class Playlist
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    
    public string UserName { get; set; } = null!;
    
    [BsonElement("items")]
    [JsonPropertyName("items")]
    public List<string> MovieIds { get; set; } = null!;
}