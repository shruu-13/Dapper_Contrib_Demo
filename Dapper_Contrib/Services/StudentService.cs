using Dapper_Contrib.Models;
using Dapper_Contrib.Repository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Services
{
	public class StudentService : IStudentService
	{
		private readonly IGenericRepository<Student> _repository;

		public StudentService(IGenericRepository<Student> repository)
		{
			_repository = repository;
		}

		public async Task<Student> GetByIdAsync(int id)
		{
			if (id <= 0)
				throw new ArgumentException("Invalid student ID");

			return await _repository.GetByIdAsync(id);
		}

		public async Task<IEnumerable<Student>> GetAllAsync()
		{
			return await _repository.GetAllAsync();
		}

		public async Task InsertAsync(Student student)
		{
			ValidateStudent(student);
			await _repository.InsertAsync(student);
		}

		public async Task UpdateAsync(Student student)
		{
			ValidateStudent(student);
			var existingStudent = await _repository.GetByIdAsync(student.Roll_no);
			if (existingStudent == null)
				throw new KeyNotFoundException("Student not found");

			await _repository.UpdateAsync(student);
		}

		public async Task DeleteAsync(int id)
		{
			if (id <= 0)
				throw new ArgumentException("Invalid student ID");

			var student = await _repository.GetByIdAsync(id);
			if (student == null)
				throw new KeyNotFoundException("Student not found");

			await _repository.DeleteAsync(id);
		}

		private void ValidateStudent(Student student)
		{
			if (student == null)
				throw new ArgumentNullException(nameof(student));

			if (string.IsNullOrWhiteSpace(student.Fname) || string.IsNullOrWhiteSpace(student.Lname))
				throw new ArgumentException("Student name cannot be empty");

					}
	}
}
