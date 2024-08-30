using Dapper_Contrib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Services
{
	public interface ISchoolService
	{
		Task<School> GetByIdAsync(int id);
		Task<IEnumerable<School>> GetAllAsync();
		Task InsertAsync(School school);
		Task UpdateAsync(School school);
		Task DeleteAsync(int id);
	}
}
