using Profilum.UserService.BLL.Models;
using static Profilum.UserService.Common.BaseModels.AppResponse;

namespace Profilum.UserService.BLL.Handlers.Interfaces;

public interface IUserHandler
{
    Task<Response<UserResponse>> Get(Guid id);

    Task<Response<List<UserResponse>>> GetAll();

    IAsyncEnumerable<UserResponse> GetAllStream();

    Task<Response<UserResponse>> Create(UserRequest request);

    Task<Response<UserResponse>> Update(UserRequest request);

    Task<Response> Delete(Guid id);

    Task<Response> DeleteAll();
}