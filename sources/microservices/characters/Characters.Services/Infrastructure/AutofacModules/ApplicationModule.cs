using Autofac;
using Characters.Domain.Repositories;
using Characters.Services.Application.Repositories;
using Common.Databases.MongoDb.Contexts;
using Common.Databases.MongoDb.Data;

namespace Characters.Services.Infrastructure.AutofacModules;

public class ApplicationModule : Module
{
    protected override void Load(ContainerBuilder builder)
    {
        builder.RegisterType<MongoDbContext>()
            .As<IMongoDbContext>()
            .InstancePerLifetimeScope();

        builder.RegisterType<UnitOfWork>()
            .As<IUnitOfWork>()
            .InstancePerLifetimeScope();

        RegisterRepositories(builder);
    }

    private void RegisterRepositories(ContainerBuilder builder)
    {
        builder.RegisterType<HeroRepository>()
            .As<IHeroRepository>()
            .InstancePerLifetimeScope();
    }
}

