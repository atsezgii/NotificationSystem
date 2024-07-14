
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Core.DataAccess
{
    public interface IRepository<T>
    {
        T? Get(Expression<Func<T, bool>> predicate, Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);

        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void SoftDelete (T entity);
    }
}
