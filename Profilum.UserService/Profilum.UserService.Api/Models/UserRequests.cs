namespace Profilum.UserService.Api.Models;

public class UserRequest
{
    public Guid Id { get; set; }
   
    public string Name { get; set; }
    
    public BLL.Models.UserRequest ConvertToBll()
    {
        return new BLL.Models.UserRequest
        {
            Id = Id,
            Name = Name
        };
    }
}