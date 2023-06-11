using Common.DomainDrivenDesign.DomainObjects;
using MongoDB.Driver;

namespace Common.Databases.MongoDb.Contexts;

public interface IMongoDbContext : IDisposable
{
    Task AddCommand(Func<Task> func);
    Task<int> SaveChanges();
    IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : IAggregateRoot;
}
