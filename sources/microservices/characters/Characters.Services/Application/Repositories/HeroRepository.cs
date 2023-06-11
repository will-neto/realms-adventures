using Characters.Domain.Aggregates;
using Characters.Domain.Repositories;
using Common.Databases.MongoDb.Contexts;
using Common.Databases.MongoDb.Data;
using Common.DomainDrivenDesign.DomainObjects;

namespace Characters.Services.Application.Repositories;

public class HeroRepository : Repository<Hero>, IRepository<Hero>, IHeroRepository
{
    public HeroRepository(IMongoDbContext context) : base(context)
    {
    }

    public void Dispose()
    {

    }
}
