using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Domain.Entities.Common;
using ECommerceAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace ECommerceAPI.Persistence.Repositories;

public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
{
    private readonly ECommerceDbContext _context;

    public WriteRepository(ECommerceDbContext context)
    {
        _context = context;
    }

    public DbSet<T> Table => _context.Set<T>();

    public async Task<bool> AddAsync(T model)
    {
        var entityEntry = await Table.AddAsync(model);
        return entityEntry.State == EntityState.Added;
    }

    public async Task<bool> AddRangeAsync(List<T> model)
    {
        await Table.AddRangeAsync(model);
        return true;
    }

    public bool Remove(T model)
    {
        var entityEntry = Table.Remove(model);
        return entityEntry.State == EntityState.Deleted;
    }

    public bool RemoveRange(List<T> data)
    {
        Table.RemoveRange(data);
        return true;
    }

    public async Task<bool> RemoveAsync(string id)
    {
        var model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        return Remove(model);
    }

    public bool Update(T model)
    {
        var entityEntry = Table.Update(model);
        return entityEntry.State == EntityState.Modified;
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}