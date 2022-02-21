using Profilum.UserService.DAL.MongoDb.Models;

namespace Profilum.UserService.DAL.Models;

public class UserResponse
{
   public Guid Id { get; set; }
   
   public string Name { get; set; }

   public UserResponse(Users userEntity)
   {

      Id = userEntity.Id;
      Name = userEntity.Name;
   }
   
   public UserResponse(UserRequest request)
   {
      Id = request.Id;
      Name = request.Name;
   }
}