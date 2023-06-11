namespace Common.DomainDrivenDesign.DomainObjects;

public interface IAggregateRoot 
{
    public Guid Id { get; set; }
    public bool IsDeleted { get; set; }
}
