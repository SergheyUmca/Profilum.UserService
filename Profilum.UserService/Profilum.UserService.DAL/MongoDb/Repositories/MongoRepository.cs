using MongoDB.Bson;
using MongoDB.Driver;

namespace Profilum.UserService.DAL.MongoDb.Repositories
{
    public class MongoRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly IMongoCollection<TEntity> _dbCollection;

        public MongoRepository(string connectionString, string databaseName)
        {
            var client = new MongoClient(connectionString);
            var db = client.GetDatabase(databaseName);
            _dbCollection = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        

        public async Task<TEntity> Single(object key)
        {
            var query = new BsonDocument("Id", BsonValue.Create(key));
            var entity = await _dbCollection.FindSync<TEntity>(query).FirstOrDefaultAsync();

            if (entity == null)
                throw new NullReferenceException("Document with key '" + key + "' not found.");

            return entity;
        }

        public async Task<IEnumerable<TEntity>> All()
        {
            var entity = await _dbCollection.FindSync(_ => true).ToListAsync();
            return entity;
        }

        public async Task<bool> Exists(object key)
        {
            var query = new BsonDocument("Id", BsonValue.Create(key));
            var entity = await _dbCollection.FindSync<TEntity>(query).FirstOrDefaultAsync();
            return (entity != null);
        }
        

        public async Task Save(TEntity item)
        {
            await _dbCollection.InsertOneAsync(item);
        }
        
        public async Task<bool> Update(object key, TEntity item)
        {
            var query = new BsonDocument("Id", BsonValue.Create(key));
            var updateResult = await _dbCollection.ReplaceOneAsync(query, item);

            return updateResult.ModifiedCount > 0;
        }

        public async Task Delete(object key) 
        {
            var query = new BsonDocument("Id", BsonValue.Create(key));
            await _dbCollection.DeleteOneAsync(query);
        }
        
        public async Task DeleteAll() 
        {
            var query = new BsonDocument();
            await _dbCollection.DeleteManyAsync(query);
        }
    }
}