using Dapper_Contrib.Models;
using Dapper_Contrib.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentController : ControllerBase
	{
		private readonly IStudentService _studentService;

		public StudentController(IStudentService studentService)
		{
			_studentService = studentService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Student>> Get(int id)
		{
			var student = await _studentService.GetByIdAsync(id);
			if (student == null)
			{
				return NotFound();
			}
			return Ok(student);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Student>>> GetAll()
		{
			var students = await _studentService.GetAllAsync();
			return Ok(students);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] Student student)
		{
			await _studentService.InsertAsync(student);
			return CreatedAtAction(nameof(Get), new { id = student.Roll_no }, student);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] Student student)
		{
			if (id != student.Roll_no)
			{
				return BadRequest();
			}
			await _studentService.UpdateAsync(student);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _studentService.DeleteAsync(id);
			return NoContent();
		}
	}
}
