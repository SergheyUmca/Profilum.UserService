﻿using Profilum.UserService.BLL.Models;
using static Profilum.UserService.Common.BaseModels.AppResponse;

namespace Profilum.UserService.BLL.Handlers.Interfaces;

public interface IUserHandler
{
    Task<Response<UserResponse>> Get(long id);

    Task<Response<List<UserResponse>>> GetAll();

    Task<Response<UserResponse>> Create(UserRequest request);

    Task<Response<UserResponse>> Update(UserRequest request);

    Task<Response> Delete(long id);

    Task<Response> DeleteAll();
}