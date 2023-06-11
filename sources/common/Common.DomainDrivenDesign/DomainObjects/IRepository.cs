namespace Common.DomainDrivenDesign.DomainObjects;

public interface IRepository<TEntity> : IDisposable where TEntity : IAggregateRoot
{
    Task Add(TEntity entity);
    Task<TEntity> GetById(Guid id);
    Task<IEnumerable<TEntity>> GetAll();
    Task Update(TEntity entity);
    Task Remove(Guid id);
}
