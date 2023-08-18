using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace EKART.API.DATA.Repositories.Base
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private bool disposed = false;
        private readonly DbContext dbContext;

        public Repository(DbContext dbContext) => this.dbContext = dbContext;

        public async Task<TEntity?> GetAsync(long id, CancellationToken cancellationToken) =>
            await dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);

        public async Task<TEntity?> GetAsync(int id, CancellationToken cancellationToken) =>
            await dbContext.Set<TEntity>().FindAsync(new object[] { id }, cancellationToken);

        public async Task<IEnumerable<TEntity>> GetAllAsync(CancellationToken cancellationToken) =>
            await dbContext.Set<TEntity>().ToListAsync(cancellationToken);

        public async Task<TEntity?> FindAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) =>
            await dbContext.Set<TEntity>().Where(predicate).FirstOrDefaultAsync(cancellationToken);

        public async Task<int> AddAsync(TEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                 await  dbContext.Set<TEntity>().AddAsync(entity);
                return await dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> UpdateAsync(TEntity entity, CancellationToken cancellationToken)
        {
            try
            {
                dbContext.Entry(entity).State = EntityState.Modified;
                return await dbContext.SaveChangesAsync(cancellationToken);
            }
            catch (Exception ex)
            {
                throw;
            }
            
        }

        public async Task<int> DeleteAsync(TEntity entity, CancellationToken cancellationToken)
        {
            dbContext.Set<TEntity>().Remove(entity);
            return await dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<IEnumerable<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) =>
            await dbContext.Set<TEntity>().Where(predicate).ToListAsync(cancellationToken);

        public async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken) =>
            await dbContext.Set<TEntity>().AnyAsync(predicate, cancellationToken);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                disposed = true;
            }
        }

        ~Repository() => Dispose(false);
    }
}
