using Microsoft.AspNetCore.Mvc;
using Profilum.UserService.Api.Models;
using Profilum.UserService.BLL.Handlers.Interfaces;

namespace Profilum.UserService.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly ILogger<UsersController> _logger;

    public UsersController(ILogger<UsersController> logger)
    {
        _logger = logger;
    }
    
    [HttpGet]
    public async Task<UserResponse> Get([FromServices]IUserHandler userHandler , long id)
    {
        var getUser = await userHandler.Get(id);
        return new UserResponse(getUser);
    }
    
    [HttpGet("GetAll")]
    public async Task<List<UserResponse>> GetAll([FromServices]IUserHandler userHandler)
    {
        var getUsers = await userHandler.GetAll();
        return getUsers.Select(u => new UserResponse(u)).ToList();
    }
    
    [HttpPost]
    public async Task<UserResponse> Create([FromServices]IUserHandler userHandler, [FromBody]UserRequest request)
    {
        var createUser = await userHandler.Create(request.ConvertToBll());
        return new UserResponse(createUser);
    }
    
    [HttpPut]
    public async Task<UserResponse> Update([FromServices]IUserHandler userHandler, [FromBody]UserRequest request)
    {
        var updateUser = await userHandler.Update(request.ConvertToBll());
        return new UserResponse(updateUser);
    }
    
    [HttpDelete]
    public async Task Delete([FromServices]IUserHandler userHandler, long id)
    {
        await userHandler.Delete(id);
    }
    
    [HttpDelete("DeleteAll")]
    public async Task DeleteAll([FromServices]IUserHandler userHandler)
    {
        await userHandler.DeleteAll();
    }
}