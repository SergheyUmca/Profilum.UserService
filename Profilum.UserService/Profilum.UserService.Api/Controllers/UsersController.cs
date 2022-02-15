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
        return new UserResponse();
    }
    
    [HttpGet]
    public async Task<UserResponse> GetAll([FromServices]IUserHandler userHandler)
    {
        return new UserResponse();
    }
    
    [HttpPost]
    public async Task<UserResponse> Create([FromServices]IUserHandler userHandler, [FromBody]UserRequest request)
    {
        return new UserResponse();
    }
    
    [HttpPut]
    public async Task<UserResponse> Update([FromServices]IUserHandler userHandler, [FromBody]UserRequest request)
    {
        return new UserResponse();
    }
    
    [HttpDelete]
    public async Task Delete([FromServices]IUserHandler userHandler, long id)
    {
        return;
    }
    
    [HttpDelete]
    public async Task Delete([FromServices]IUserHandler userHandler)
    {
        return;
    }
}