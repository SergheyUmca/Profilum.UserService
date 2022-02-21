using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Profilum.UserService.DAL.MongoDb.Models;

[BsonIgnoreExtraElements]
public class Users
{
    [BsonId]
    [BsonIgnoreIfDefault]
    [DataMember]
    public ObjectId _id { get; set; }
    
    [DataMember]
    public Guid Id { get; set; }
 
    [DataMember]
    public string Name { get; set; }
}