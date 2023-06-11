using Autofac;
using MediatR.Extensions.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection.Builder;

namespace Characters.Services.Infrastructure.AutofacModules;

public class MediatorModule : Module
{
    protected override void Load(ContainerBuilder builder)
        => builder.RegisterMediatR(
                MediatRConfigurationBuilder
                    .Create(System.Reflection.Assembly.GetExecutingAssembly())
                    .WithAllOpenGenericHandlerTypesRegistered()
                    .WithRegistrationScope(RegistrationScope.Scoped) // currently only supported values are `Transient` and `Scoped`
                    .Build()
            );
}

