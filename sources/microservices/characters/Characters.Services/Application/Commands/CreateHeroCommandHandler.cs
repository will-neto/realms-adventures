using Characters.Domain.Aggregates;
using Characters.Domain.Repositories;
using Common.CQRS;
using Common.CQRS.Commands;
using Common.Databases.MongoDb.Data;

namespace Characters.Services.Application.Commands;

public class CreateHeroCommandHandler : ICommandHandler<CreateHeroCommand, Guid>
{
    private readonly IUnitOfWork _uow;
    private readonly IHeroRepository _heroRepository;

    public CreateHeroCommandHandler(IUnitOfWork uow, IHeroRepository heroRepository)
    {
        _uow = uow;
        _heroRepository = heroRepository;
    }

    public async Task<Result<Guid>> Handle(CreateHeroCommand request, CancellationToken cancellationToken)
    {
        var entity = new Hero(request.Hero.Name);
        await _heroRepository.Add(entity);

        return !await _uow.Commit()
            ? Result.Fail<Guid>("An error occurred while trying to create the Hero.")
            : Result.Ok(entity.Id);
    }
}