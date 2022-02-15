﻿using Profilum.UserService.BLL.Handlers.Interfaces;
using Profilum.UserService.BLL.Models;
using Profilum.UserService.DAL.MongoDb.Repositories;

namespace Profilum.UserService.BLL.Handlers.Implementations;

public class UserHandler : IUserHandler
{
    private readonly MongoUserRepository _mongoUserRepository;
    
    public UserHandler(string connectionString, string dbName)
    {
        _mongoUserRepository = new MongoUserRepository(connectionString, dbName);
    }
    
    public async Task<List<UserResponse>> GetAll()
    {
        try
        {
            var getAllUsers = await _mongoUserRepository.GetAll();

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
            var getUser = await _mongoUserRepository.Get(id);

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
            var createUser = await _mongoUserRepository.Create(request.ConvertToDal());

            return new UserResponse(createUser);

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
            var updateUser = await _mongoUserRepository.Update(request.ConvertToDal());

            return new UserResponse(updateUser);

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
            await _mongoUserRepository.Delete(id);
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
            await _mongoUserRepository.DeleteAll();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}