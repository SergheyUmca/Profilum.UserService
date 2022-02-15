
namespace Profilum.UserService.DAL;

public interface IRepository<TEntity> where TEntity : class
{
    Task<TEntity> Single(object key);
    
    Task<IEnumerable<TEntity>> All();
    
    Task<bool> Exists(object key);
    
    Task Save(TEntity item);
    
    Task Delete(object key);
}