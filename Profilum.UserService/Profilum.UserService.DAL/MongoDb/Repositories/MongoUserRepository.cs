using Profilum.UserService.Common;
using Profilum.UserService.Common.BaseModels;
using Profilum.UserService.DAL.Models;
using Profilum.UserService.DAL.MongoDb.Models;
using static Profilum.UserService.Common.BaseModels.AppResponse;

namespace Profilum.UserService.DAL.MongoDb.Repositories;

public class MongoUserRepository
{
    private readonly IRepository<Users> _repository;
        
    public MongoUserRepository(string connectionString, string databaseName)
    {
        _repository = new MongoRepository<Users>(connectionString, databaseName);
    }
    
    
    public async Task<Response<UserResponse>> Get(Guid id)
    {
        try
        {
            var getUser = await _repository.Single(id, "Id");
            
            return new Response<UserResponse>(new UserResponse(getUser));

        }
        catch (CustomException ce)
        {
            return new ErrorResponse<UserResponse>(ce.LastErrorMessage, ce.LastResultCode);
        }
        catch (Exception e)
        {
            return new ErrorResponse<UserResponse>(e.Message);
        }
    }
    
    public async Task<Response<long>> TotalCount()
    {
        try
        {
            var getUser = await _repository.Count();
            
            return new Response<long>(getUser);

        }
        catch (CustomException ce)
        {
            return new ErrorResponse<long>(ce.LastErrorMessage, ce.LastResultCode);
        }
        catch (Exception e)
        {
            return new ErrorResponse<long>(e.Message);
        }
    }
    
    public async Task<Response<List<UserResponse>>> GetAll()
    {
        try
        {
            var getAllUsers = await _repository.All();

            return new Response<List<UserResponse>>(getAllUsers.Select(u => new UserResponse(u)).ToList());
        }
        catch (CustomException ce)
        {
            return new ErrorResponse<List<UserResponse>>(ce.LastErrorMessage, ce.LastResultCode);
        }
        catch (Exception e)
        {
            return new ErrorResponse<List<UserResponse>>(e.Message);
        }
    }
    
    public async IAsyncEnumerable<UserResponse> GetAllAsyncEnumerable()
    {
        await foreach (var userResponse in _repository.GetAllStream()) 
            yield return new UserResponse(userResponse);
    }
    
   
    
    public async Task<Response<UserResponse>> Create( UserRequest request)
    {
        try
        {
            request.Id = Guid.NewGuid();
            await _repository.Save(request.ConvertToEntity());
            
            return new Response<UserResponse>(new UserResponse(request));

        }
        catch (CustomException ce)
        {
            return new ErrorResponse<UserResponse>(ce.LastErrorMessage, ce.LastResultCode);
        }
        catch (Exception e)
        {
            return new ErrorResponse<UserResponse>(e.Message);
        }
    }
    
    public async Task<Response<UserResponse>> Update(UserRequest request)
    {
        try
        {
            var update = await _repository.Update(request.Id, nameof(request.Id), request.ConvertToEntity());
            if (!update)
                throw new CustomException(ResponseCodes.DATABASE_ERROR, $"Entity not updated");
            
            return new Response<UserResponse>(new UserResponse(request));
        }
        catch (CustomException ce)
        {
            return new ErrorResponse<UserResponse>(ce.LastErrorMessage, ce.LastResultCode);
        }
        catch (Exception e)
        {
            return new ErrorResponse<UserResponse>(e.Message);
        }
    }
    
    public async Task<Response> Delete(Guid id)
    {
        try
        {
            await _repository.Delete(id, "Id");

            return new Response();
        }
        catch (CustomException ce)
        {
            return new ErrorResponse(ce.LastErrorMessage, ce.LastResultCode);
        }
        catch (Exception e)
        {
            return new ErrorResponse(e.Message);
        }
    }
    
    public async Task<Response> DeleteAll()
    {
        try
        {
            await _repository.DeleteAll();

            return new Response();
        }
        catch (CustomException ce)
        {
            return new ErrorResponse(ce.LastErrorMessage, ce.LastResultCode);
        }
        catch (Exception e)
        {
            return new ErrorResponse(e.Message);
        }
    }
}