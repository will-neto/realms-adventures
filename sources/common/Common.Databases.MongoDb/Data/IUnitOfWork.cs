namespace Common.Databases.MongoDb.Data;

public interface IUnitOfWork : IDisposable
{
    Task<bool> Commit();
}
