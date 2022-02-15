using Profilum.UserService.BLL.Models;

namespace Profilum.UserService.BLL.Handlers.Interfaces;

public interface IUserHandler
{
    Task<UserResponse> Get(long id);

    Task<UserResponse> Create(UserRequest request);

    Task<UserResponse> Update(UserRequest request);

    Task Delete(long id);
}