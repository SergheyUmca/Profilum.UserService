using Grpc.Core;
using Profilum.UserService.BLL.Handlers.Interfaces;
using Profilum.UserService.BLL.Models;
using static Profilum.UserService.UserService;

namespace Profilum.UserService.Api.Services;

internal class UserService : UserServiceBase
{
     //private readonly ILogger<UserService> _logger;
     private readonly IUserHandler _userHandler;

     public UserService(IUserHandler userHandler)
    {
        //_logger = logger;
        _userHandler = userHandler;
    }
        

    public override async Task<UserFullReply> GetUser(UserGetRequest request, ServerCallContext context)
    {
        var getUser = await _userHandler.Get(Guid.Parse(request.Id));
        if(!getUser.IsSuccess)
        {
            //set statusCode
        }
        
        return new UserFullReply
        {
            Id = getUser.Data.Id.ToString(),
            Name = getUser.Data.Name,
            ReplyStateCode = (int)getUser.ResultCode
        };
    }

    public override async Task GetAllUsers(EmptyRequest request , IServerStreamWriter<UserFullReply> responseStream,
        ServerCallContext context)
    {
        await foreach (var userResponse in _userHandler.GetAllStream())
        {
            await responseStream.WriteAsync(new UserFullReply
            {
                Id = userResponse.Id.ToString(),
                Name = userResponse.Name
            });
        }
    }


    public override async Task<UserFullReply> CreateUser(UserCreateRequest request, ServerCallContext context)
    {
        var createUser = await _userHandler.Create(new UserRequest
        {
            Name = request.Name
        });
        if(!createUser.IsSuccess)
        {
            //set statusCode
        }
        
        return new UserFullReply
        {
            Id = createUser.Data.Id.ToString(),
            Name = createUser.Data.Name,
            ReplyStateCode = (int)createUser.ResultCode
        };
    }
     
    public override async Task<UserFullReply> UpdateUser(UserCreateRequest request, ServerCallContext context)
    {
        var updateUser = await _userHandler.Update(new UserRequest
        {
            Id = Guid.Parse(request.Id),
            Name = request.Name
        });
        if(!updateUser.IsSuccess)
        {
            //set statusCode
        }
        
        return new UserFullReply
        {
            Id = updateUser.Data.Id.ToString(),
            Name = updateUser.Data.Name,
            ReplyStateCode = (int)updateUser.ResultCode
        };
    }
      
    public override async Task<EmptyReply> DeleteUser(UserGetRequest request, ServerCallContext context)
    {
        var deleteUser = await _userHandler.Delete(Guid.Parse(request.Id));
        if(!deleteUser.IsSuccess)
        {
            //set statusCode
        }
        
        return new EmptyReply
        {
            ReplyStateCode = (int)deleteUser.ResultCode
        };
    }
    
    public override async Task<EmptyReply> DeleteAllUsers(EmptyRequest request, ServerCallContext context)
    {
        var deleteAll = await _userHandler.DeleteAll();
        if(!deleteAll.IsSuccess)
        {
            //set statusCode
        }
        
        return new EmptyReply
        {
            ReplyStateCode = (int)deleteAll.ResultCode
        };
    }
}