namespace Common.DomainDrivenDesign.DomainObjects;

public interface IRepository<T> : IDisposable where T : IAggregateRoot
{

}
