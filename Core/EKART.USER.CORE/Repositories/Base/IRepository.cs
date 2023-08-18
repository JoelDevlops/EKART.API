using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EKART.API.DATA.Repositories.Base
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
       Task<TEntity> GetAsync(long id,CancellationToken cancellationToken);
       Task<TEntity> GetAsync(int id, CancellationToken cancellationToken);
       Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken);
       Task<TEntity> FindAsync(Expression<Func<TEntity,bool>> predicate, CancellationToken cancellationToken);
       Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
       Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken);
       Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken);
       Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken);
       Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken);
    }
}
