using Common.DomainDrivenDesign.DomainObjects;

namespace Characters.Domain.Aggregates; 

public abstract class Character : Entity, IAggregateRoot
{
    public string Name { get; set; } = null!;
}
