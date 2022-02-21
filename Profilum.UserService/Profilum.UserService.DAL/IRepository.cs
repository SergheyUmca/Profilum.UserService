﻿
namespace Profilum.UserService.DAL;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> Single(object value, string fieldName);

    Task<long> Count();

    IAsyncEnumerable<TEntity> GetAllStream();

    Task<IEnumerable<TEntity>> All();
    
    Task<bool> Exists(object value, string fieldName);
    
    Task Save(TEntity item);

    Task<bool> Update(object value, string fieldName, TEntity item);
    
    Task Delete(object value, string fieldName);

    Task DeleteAll();
}