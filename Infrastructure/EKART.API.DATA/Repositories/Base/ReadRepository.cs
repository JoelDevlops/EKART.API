using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

namespace EKART.API.DATA.Repositories.Base
{
    public class ReadRepository<TEntity> : IDisposable where TEntity : class
    {
        private bool disposed = false;
        protected readonly SqlConnection connection;

        public ReadRepository(IConfiguration configuration)
        {
            DefaultTypeMap.MatchNamesWithUnderscores = true;
            connection = new SqlConnection(configuration.GetConnectionString("DbConnection"));
        }

        protected async Task<TEntity> FindAsync(string procedureName, CancellationToken cancellationToken) =>
            await connection.QueryFirstOrDefaultAsync<TEntity>(CreateCommand(procedureName, cancellationToken));
        protected async Task<TEntity> FindAsync(string procedureName, DynamicParameters dynamicParameters, CancellationToken cancellationToken) =>
           await connection.QueryFirstOrDefaultAsync<TEntity>(CreateCommand(procedureName, dynamicParameters, cancellationToken));
        protected async Task<IEnumerable<TEntity>> FindAllAsync(string procedureName, CancellationToken cancellationToken) =>
          await connection.QueryAsync<TEntity>(CreateCommand(procedureName, cancellationToken));
        protected async Task<IEnumerable<TEntity>> FindAllAsync(string procedureName, DynamicParameters dynamicParameters, CancellationToken cancellationToken) =>
         await connection.QueryAsync<TEntity>(CreateCommand(procedureName, dynamicParameters, cancellationToken));
        protected CommandDefinition CreateCommand(string procedureName, CancellationToken cancellationToken) =>
           new CommandDefinition(procedureName, commandType: CommandType.StoredProcedure, cancellationToken: cancellationToken);
        protected CommandDefinition CreateCommand(string procedureName, DynamicParameters dynamicParameters, CancellationToken cancellationToken) =>
           new CommandDefinition(procedureName, commandType: CommandType.StoredProcedure, parameters: dynamicParameters, cancellationToken: cancellationToken);
      

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
                    connection.Dispose();
                }
                disposed = true;
            }
        }

        ~ReadRepository() => Dispose(false);
    }
}
