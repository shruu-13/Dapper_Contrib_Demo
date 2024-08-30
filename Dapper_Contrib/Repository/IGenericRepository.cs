using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Repository
{
	public interface IGenericRepository<T>
	{
		Task<T> GetByIdAsync(int id);
		Task<IEnumerable<T>> GetAllAsync();
		Task InsertAsync(T entity);
		Task UpdateAsync(T entity);
		Task DeleteAsync(int id);
	}
}
