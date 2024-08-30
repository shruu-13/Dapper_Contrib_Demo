using Dapper_Contrib.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Services
{
	public interface IStudentService
	{
		Task<Student> GetByIdAsync(int id);
		Task<IEnumerable<Student>> GetAllAsync();
		Task InsertAsync(Student student);
		Task UpdateAsync(Student student);
		Task DeleteAsync(int id);
	}
}
