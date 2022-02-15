using Profilum.UserService.DAL.Models;
using Profilum.UserService.DAL.MongoDb.Models;

namespace Profilum.UserService.DAL.MongoDb.Repositories;

public class MongoUserRepository
{
    private IRepository<Users> _repository;
        
    public MongoUserRepository(string connectionString, string databaseName)
    {
        _repository = new MongoRepository<Users>(connectionString, databaseName);
    }
    
    
    public async Task<List<UserResponse>> GetAll()
    {
        try
        {
            var getAllUsers = await _repository.All();

            return getAllUsers.Select(u => new UserResponse(u)).ToList();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<UserResponse> Get(long id)
    {
        try
        {
            var getUser = await _repository.Single(id);
            
            return new UserResponse(getUser);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<UserResponse> Create( UserRequest request)
    {
        try
        {
            await _repository.Save(request.ConvertToEntity());
            
            return new UserResponse(request);

        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task<UserResponse> Update(UserRequest request)
    {
        try
        {
            var update = await _repository.Update(request.Id, request.ConvertToEntity());
            if (!update)
                throw new Exception();
            
            return new UserResponse(request);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task Delete(long id)
    {
        try
        {
             await _repository.Delete(id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
    
    public async Task DeleteAll()
    {
        try
        {
            await _repository.DeleteAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}