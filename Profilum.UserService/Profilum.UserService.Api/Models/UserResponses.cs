namespace Profilum.UserService.Api.Models;

public class UserResponse
{
   public Guid Id { get; set; }
   
   public string Name { get; set; }
   
   public UserResponse(BLL.Models.UserResponse bllResponse)
   {
      Id = bllResponse.Id;
      Name = bllResponse.Name;
   }
}