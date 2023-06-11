using Characters.Services.Application.DTOs;
using Common.CQRS.Commands;

namespace Characters.Services.Application.Commands;

public class CreateHeroCommand : ICommand<Guid>
{
    public HeroDTO Hero { get; }
    public CreateHeroCommand(HeroDTO hero) => Hero = hero;
}

