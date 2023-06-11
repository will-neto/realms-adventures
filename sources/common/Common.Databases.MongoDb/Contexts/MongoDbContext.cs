using Common.Databases.MongoDb.Configurations;
using Common.DomainDrivenDesign.DomainObjects;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Common.Databases.MongoDb.Contexts;

public class MongoDbContext : IMongoDbContext
{
    private readonly IConfiguration _configuration;
    private readonly ICollection<Func<Task>> _commands;
    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;
    //private IClientSessionHandle _session;

    public MongoDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
        _commands = new List<Func<Task>>();

        var options = _configuration.GetSection(MongoDbOptions.Section).Get<MongoDbOptions>();
        _client = new MongoClient(options!.ConnectionString);
        _database = _client.GetDatabase(options!.DataBaseName);
    }

    //public IClientSessionHandle Session { get; set; }

    public Task AddCommand(Func<Task> func)
    {
        _commands.Add(func);
        return Task.CompletedTask;
    }

    public IMongoCollection<TEntity> GetCollection<TEntity>() where TEntity : Entity
        => _database.GetCollection<TEntity>(typeof(TEntity).Name);

    public async Task<int> SaveChanges()
    {
        using (var session = await _client.StartSessionAsync())
        {
            session.StartTransaction();
            var commandsTasks = _commands.Select(task => task());

            await Task.WhenAll(commandsTasks);
            await session.CommitTransactionAsync();
        }

        var quantity = _commands.Count;
        _commands.Clear();

        return quantity;
    }

    public void Dispose()
    {
        //Session?.Dispose();
        GC.SuppressFinalize(this);
    }
}