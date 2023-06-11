using Characters.Services.Application.Models;
using Common.CQRS.Queries;


namespace Characters.Services.Application.Queries.ProjectQueries;

internal class GetProjectByIdQuery : IQuery<HeroModel>
{
    public Guid Id { get; }

    public GetProjectByIdQuery(Guid id)
    {
        Id = id;
    }
}
