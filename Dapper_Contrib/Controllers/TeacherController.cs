using Dapper_Contrib.Models;
using Dapper_Contrib.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dapper_Contrib.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly ITeacherService _teacherService;

		public TeacherController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}

		[HttpGet("{id}")]
		public async Task<ActionResult<Teacher>> Get(int id)
		{
			var teacher = await _teacherService.GetByIdAsync(id);
			if (teacher == null)
			{
				return NotFound();
			}
			return Ok(teacher);
		}

		[HttpGet]
		public async Task<ActionResult<IEnumerable<Teacher>>> GetAll()
		{
			var teachers = await _teacherService.GetAllAsync();
			return Ok(teachers);
		}

		[HttpPost]
		public async Task<ActionResult> Post([FromBody] Teacher teacher)
		{
			await _teacherService.InsertAsync(teacher);
			return CreatedAtAction(nameof(Get), new { id = teacher.Teacher_id }, teacher);
		}

		[HttpPut("{id}")]
		public async Task<ActionResult> Put(int id, [FromBody] Teacher teacher)
		{
			if (id != teacher.Teacher_id)
			{
				return BadRequest();
			}
			await _teacherService.UpdateAsync(teacher);
			return NoContent();
		}

		[HttpDelete("{id}")]
		public async Task<ActionResult> Delete(int id)
		{
			await _teacherService.DeleteAsync(id);
			return NoContent();
		}
	}
}
