using Profilum.UserService.BLL.Handlers.Interfaces;
using Profilum.UserService.BLL.Models;

namespace Profilum.UserService.BLL.Handlers.Implementations;

public class UserHandler : IUserHandler
{
    private readonly string _connectionString;
    private readonly string _dbName;
    
    public UserHandler(string connectionString, string dbName)
    {
        _connectionString = connectionString;
        _dbName = dbName;
    }
    
    public async Task<List<UserResponse>> GetAll()
    {
        return new List<UserResponse>();
    }
    
    public async Task<UserResponse> Get(long id)
    {
        return new UserResponse();
    }
    
    public async Task<UserResponse> Create( UserRequest request)
    {
        return new UserResponse();
    }
    
    public async Task<UserResponse> Update(UserRequest request)
    {
        return new UserResponse();
    }
    
    public async Task Delete(long id)
    {
        return;
    }
    
    public async Task DeleteAll()
    {
        return;
    }
}