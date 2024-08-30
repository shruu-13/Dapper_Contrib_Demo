using Dapper_Contrib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Services
{
	public interface ITeacherService
	{
		Task<Teacher> GetByIdAsync(int id);
		Task<IEnumerable<Teacher>> GetAllAsync();
		Task InsertAsync(Teacher teacher);
		Task UpdateAsync(Teacher teacher);
		Task DeleteAsync(int id);
	}
}
