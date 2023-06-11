using Common.Databases.MongoDb.Contexts;

namespace Common.Databases.MongoDb.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly IMongoDbContext _context;

    public UnitOfWork(IMongoDbContext context)
    {
        _context = context;
    }

    public async Task<bool> Commit() => await _context.SaveChanges() > 0;

    public void Dispose()
    {
        _context?.Dispose();
        GC.SuppressFinalize(this);
    }
}
