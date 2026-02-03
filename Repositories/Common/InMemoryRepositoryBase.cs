using System.Collections.Concurrent;

namespace IsiGatewayProcess.Repositories.Common;

public class InMemoryRepositoryBase<T>
{
    protected readonly ConcurrentDictionary<Guid, T> Store = new();

    public Task<T?> GetAsync(Guid id)
    {
        Store.TryGetValue(id, out var value);
        return Task.FromResult(value);
    }

    public Task<IReadOnlyList<T>> ListAsync(int skip, int take)
    {
        IReadOnlyList<T> items = Store.Values.Skip(skip).Take(take).ToList();
        return Task.FromResult(items);
    }

    public Task<int> CountAsync()
    {
        return Task.FromResult(Store.Count);
    }

    public Task<T> AddAsync(Guid id, T entity)
    {
        Store[id] = entity;
        return Task.FromResult(entity);
    }

    public Task<bool> UpdateAsync(Guid id, T entity)
    {
        if (!Store.TryGetValue(id, out var existing))
        {
            return Task.FromResult(false);
        }

        var updated = Store.TryUpdate(id, entity, existing);
        return Task.FromResult(updated);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var removed = Store.TryRemove(id, out _);
        return Task.FromResult(removed);
    }
}
