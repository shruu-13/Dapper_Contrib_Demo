using Dapper.Contrib.Extensions;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Dapper_Contrib.Repository
{
	public class GenericRepository<T> : IGenericRepository<T> where T : class
	{
		private readonly DapperContext _dapperContext;

		public GenericRepository(DapperContext dapperContext)
		{
			_dapperContext = dapperContext;
		}

		private IDbConnection Connection => _dapperContext.CreateConnection();

		public async Task<T> GetByIdAsync(int id)
		{
			using var connection = Connection;
			return await connection.GetAsync<T>(id);
		}

		public async Task<IEnumerable<T>> GetAllAsync()
		{
			using var connection = Connection;
			return await connection.GetAllAsync<T>();
		}

		public async Task InsertAsync(T entity)
		{
			using var connection = Connection;
			await connection.InsertAsync(entity);
		}

		public async Task UpdateAsync(T entity)
		{
			using var connection = Connection;
			await connection.UpdateAsync(entity);
		}

		public async Task DeleteAsync(int id)
		{
			using var connection = Connection;
			var entity = await GetByIdAsync(id);
			if (entity != null)
			{
				await connection.DeleteAsync(entity);
			}
		}
	}
}
