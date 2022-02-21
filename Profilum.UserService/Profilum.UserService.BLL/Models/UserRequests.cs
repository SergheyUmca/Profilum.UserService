namespace Profilum.UserService.BLL.Models;

public class UserRequest
{
    public Guid Id { get; set; }
   
    public string Name { get; set; }
    
    public DAL.Models.UserRequest ConvertToDal()
    {
        return new DAL.Models.UserRequest
        {
            Id = Id,
            Name = Name
        };
    }
}