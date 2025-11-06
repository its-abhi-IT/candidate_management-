using CandidateManagement.Data.Mssql;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace CandidateManagement.Data.MssqlDb;
public class DbFactoryBase<T> : IDbFactoryBase<T> where T : class
{

    protected readonly DbContext _context;
    protected readonly DbSet<T> _dbSet;
    public DbFactoryBase(DbContext context)
    {
        _context = context;
        _dbSet = context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<T> AddAsync(T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    public async Task<bool> UpdateAsync(T entity)
    {
        _dbSet.Update(entity);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var entity = await _dbSet.FindAsync(id);
        if (entity == null) return false;

        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();
        return true;
    }
    public async Task<IEnumerable<T>> GetAsync(
    Expression<Func<T, bool>>? predicate = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    int? skip = null,
    int? take = null)
    {
        IQueryable<T> query = _dbSet;

        if (predicate != null)
            query = query.Where(predicate);

        if (orderBy != null)
            query = orderBy(query);

        if (skip.HasValue)
            query = query.Skip(skip.Value);

        if (take.HasValue)
            query = query.Take(take.Value);

        return await query.ToListAsync();
    }

}