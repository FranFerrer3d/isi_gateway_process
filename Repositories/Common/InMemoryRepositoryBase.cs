using System.Collections.Concurrent;

namespace IsiGatewayProcess.Repositories.Common;

public class InMemoryRepositoryBase<T>
{
    private readonly ConcurrentDictionary<Guid, T> _store = new();

    public Task<T?> GetAsync(Guid id)
    {
        _store.TryGetValue(id, out var value);
        return Task.FromResult(value);
    }

    public Task<IReadOnlyList<T>> ListAsync(int skip, int take)
    {
        IReadOnlyList<T> items = _store.Values.Skip(skip).Take(take).ToList();
        return Task.FromResult(items);
    }

    public Task<int> CountAsync()
    {
        return Task.FromResult(_store.Count);
    }

    public Task<T> AddAsync(Guid id, T entity)
    {
        _store[id] = entity;
        return Task.FromResult(entity);
    }

    public Task<bool> UpdateAsync(Guid id, T entity)
    {
        if (!_store.TryGetValue(id, out var existing))
        {
            return Task.FromResult(false);
        }

        var updated = _store.TryUpdate(id, entity, existing);
        return Task.FromResult(updated);
    }

    public Task<bool> DeleteAsync(Guid id)
    {
        var removed = _store.TryRemove(id, out _);
        return Task.FromResult(removed);
    }
}
