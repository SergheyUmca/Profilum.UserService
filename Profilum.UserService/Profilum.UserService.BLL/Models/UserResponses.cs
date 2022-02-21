namespace Profilum.UserService.BLL.Models;

public class UserResponse
{
   public Guid Id { get; set; }
   
   public string Name { get; set; }

   public UserResponse(DAL.Models.UserResponse dbResponse)
   {
      Id = dbResponse.Id;
      Name = dbResponse.Name;
   }
}