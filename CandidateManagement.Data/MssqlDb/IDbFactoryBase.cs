using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CandidateManagement.Data.Mssql;

public interface IDbFactoryBase<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetByIdAsync(int id);
    Task<T> AddAsync(T entity);
    Task<bool> UpdateAsync(T entity);
    Task<bool> DeleteAsync(int id);
    Task<IEnumerable<T>> GetAsync(
    Expression<Func<T, bool>>? predicate = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null,
    int? skip = null,
    int? take = null);
}
