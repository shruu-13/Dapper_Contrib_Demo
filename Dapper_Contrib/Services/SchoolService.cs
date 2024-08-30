using Dapper_Contrib.Models;
using Dapper_Contrib.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Services
{
	public class SchoolService : ISchoolService
	{
		private readonly IGenericRepository<School> _repository;

		public SchoolService(IGenericRepository<School> repository)
		{
			_repository = repository;
		}

		public async Task<School> GetByIdAsync(int id)
		{
			if (id <= 0)
				throw new ArgumentException("Invalid school ID");

			return await _repository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<School>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task InsertAsync(School school)
		{
			ValidateSchool(school);
			await _repository.InsertAsync(school);
		}

		public async Task UpdateAsync(School school)
		{
			ValidateSchool(school);
			var existingSchool = await _repository.GetByIdAsync(school.School_Id);
			if (existingSchool == null)
				throw new KeyNotFoundException("School not found");

			await _repository.UpdateAsync(school);
		}

		public async Task DeleteAsync(int id)
		{
			if (id <= 0)
				throw new ArgumentException("Invalid school ID");

			var school = await _repository.GetByIdAsync(id);

			if (school == null)
				throw new KeyNotFoundException("School not found");

			await _repository.DeleteAsync(id);
		}

		private void ValidateSchool(School school)
		{
			if (school == null)
				throw new ArgumentNullException(nameof(school));

			if (string.IsNullOrWhiteSpace(school.Scl_name))
				throw new ArgumentException("School name cannot be empty");
					}
	}
}
