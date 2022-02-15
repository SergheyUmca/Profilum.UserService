using Profilum.UserService.DAL.MongoDb.Models;

namespace Profilum.UserService.DAL.Models;

public class UserRequest
{
    public long Id { get; set; }
   
    public string Name { get; set; }

    public Users ConvertToEntity()
    {
        return new Users
        {
            Id = Id,
            Name = Name
        };
    }
}