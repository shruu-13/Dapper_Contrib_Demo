using Dapper_Contrib.Models;
using Dapper_Contrib.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Services
{
	public class TeacherService : ITeacherService
	{
		private readonly IGenericRepository<Teacher> _repository;

		public TeacherService(IGenericRepository<Teacher> repository)
		{
			_repository = repository;
		}

		public async Task<Teacher> GetByIdAsync(int id)
		{
			if (id <= 0)
				throw new ArgumentException("Invalid teacher ID");

			return await _repository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<Teacher>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task InsertAsync(Teacher teacher)
		{
			ValidateTeacher(teacher);
			await _repository.InsertAsync(teacher);
		}

		public async Task UpdateAsync(Teacher teacher)
		{
			ValidateTeacher(teacher);
			var existingTeacher = await _repository.GetByIdAsync(teacher.Teacher_id);
			if (existingTeacher == null)
				throw new KeyNotFoundException("Teacher not found");

			await _repository.UpdateAsync(teacher);
		}

		public async Task DeleteAsync(int id)
		{
			if (id <= 0)
				throw new ArgumentException("Invalid teacher ID");

			var teacher = await _repository.GetByIdAsync(id);
			if (teacher == null)
				throw new KeyNotFoundException("Teacher not found");

			await _repository.DeleteAsync(id);
		}

		private void ValidateTeacher(Teacher teacher)
		{
			if (teacher == null)
				throw new ArgumentNullException(nameof(teacher));

			if (string.IsNullOrWhiteSpace(teacher.F_name) || string.IsNullOrWhiteSpace(teacher.L_name))
				throw new ArgumentException("Teacher name cannot be empty");

					}
	}
}
