using Common.Databases.MongoDb.Contexts;
using Common.DomainDrivenDesign.DomainObjects;
using MongoDB.Driver;

namespace Common.Databases.MongoDb.Data;

public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : IAggregateRoot
{
    private readonly IMongoDbContext _context;
    private readonly IMongoCollection<TEntity> _collection;

    public Repository(IMongoDbContext context)
    {
        _context = context;
        _collection = _context.GetCollection<TEntity>();
    }

    public virtual Task Add(TEntity entity)
        => _context.AddCommand(async () => await _collection.InsertOneAsync(entity));

    public virtual async Task<IEnumerable<TEntity>> GetAll()
    {
        var all = await _collection.FindAsync(Builders<TEntity>.Filter.Empty);
        return all.ToList();
    }

    public virtual async Task<TEntity> GetById(Guid id)
    {
        var data = await _collection.FindAsync(x => x.Id == id && !x.IsDeleted);
        return data.SingleOrDefault();
    }

    public virtual Task Remove(Guid id)
        => _context.AddCommand(async () => await _collection.DeleteOneAsync(Builders<TEntity>.Filter.Eq("_id", id)));

    public virtual Task Update(TEntity entity)
        => _context.AddCommand(async () => await _collection.ReplaceOneAsync(Builders<TEntity>.Filter.Eq("_id", entity.Id), entity));

    public void Dispose()
        => GC.SuppressFinalize(this);
}