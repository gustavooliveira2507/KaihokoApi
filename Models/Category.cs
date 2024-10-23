using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace KaihokoApi.Models;
public class Category{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? _id{get;set;}    
    [BsonElement("Name")]
    public required string Name{get;set;}	
    public string? Description{get;set;} = null;
}